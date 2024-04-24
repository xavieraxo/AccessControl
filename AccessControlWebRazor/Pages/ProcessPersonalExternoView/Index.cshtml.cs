using Microsoft.AspNetCore.Mvc.RazorPages;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using AccessControlWebRazor.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.ProcessPersonalExternoView
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [BindProperty]
        public SearchViewModel SearchModel { get; set; }
        public List<ProcesamientoPersonalExterno> ProcesamientoPersonalExterno { get; set; }
        public List<Models.CentroCosto> CentroCostos { get; set; }

        public async Task OnGetAsync(List<ProcesamientoPersonalExterno> procesamientoPExterno)
        {
            if (procesamientoPExterno.Count == 0)
            {
                ProcesamientoPersonalExterno = await _mediator.Send(new GetProcessPersonalExternoByCCostoIdQuery(0));

                foreach (var procesoPersonal in ProcesamientoPersonalExterno)
                {
                    procesoPersonal.DNI ??= "-";
                    procesoPersonal.HoraEgreso ??= "-";
                    procesoPersonal.HoraIngreso ??= "-";
                    procesoPersonal.EstadoFichada ??= "-";
                    procesoPersonal.CentroCostoDesc ??= "-";
                    procesoPersonal.Fecha ??= "-";
                    procesoPersonal.TotalHoras ??= "-";
                }
            }
            else
            {
                ProcesamientoPersonalExterno = procesamientoPExterno;
            }
        }

        public IActionResult OnGetEditar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return RedirectToPage("./Edit", new { id });
        }
        public async Task GetCenCos()
        {
            CentroCostos = await _mediator.Send(new GetAllCentroCostoQuery());
        }

        public async Task<IActionResult> OnPostSearch()
        {
            DateTime? desde = null;
            DateTime? hasta = null;
            if (SearchModel.StartDate != Convert.ToDateTime("1/1/0001 00:00:00") && SearchModel.EndDate != Convert.ToDateTime("1/1/0001 00:00:00"))
            {
                desde = SearchModel.StartDate;
                hasta = SearchModel.EndDate;
            }

            var query = new GetProcessPersonalExternoByFilterQuery(SearchModel.Filter, desde, hasta);


            var result = await _mediator.Send(query);
            var listaDepurada = result.Where(x => x.CentroCostoId == 0).ToList();
            await OnGetAsync(listaDepurada);
            return Page();
        }
    }
}
