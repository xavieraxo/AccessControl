using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using AccessControlWebRazor.Pages.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.Procesamiento
{

    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator/*, IHvAC hvAC*/)
        {
            _mediator = mediator;

        }
        [BindProperty]
        public SearchViewModel SearchModel { get; set; }
        public List<Models.Procesamiento> ProcesamientoModel { get; set; }
        public List<Models.CentroCosto> CentroCostos { get; set; }

        public async Task OnGetAsync(List<Models.Procesamiento> procesamientos)
        {
            if (procesamientos.Count == 0)
            {
                ProcesamientoModel = await _mediator.Send(new GetProcesamientosByCentroCostoQuery(0));
                

                foreach (var proceso in ProcesamientoModel)
                {
                    proceso.Legajo ??= "-";
                    proceso.DNI ??= "-";
                    proceso.HoraIngreso ??= "-";
                    proceso.HoraEgreso ??= "-";
                    proceso.TotalHoras ??= "-";
                    proceso.Procesado ??= false;
                    proceso.ProcedenciaEmpleado ??= "-";
                    proceso.EstadoFichada ??= "-";
                }
            }
            else
            {
                ProcesamientoModel = procesamientos;
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

            var query = new GetProcesamientoPersonalByFilterQuery(SearchModel.Filter, desde, hasta);

            var result = await _mediator.Send(query);
            var listaDepurada = result.Where(x => x.CentroCosto == 0).ToList();
            await OnGetAsync(listaDepurada);
            return Page();


        }

    }
}
