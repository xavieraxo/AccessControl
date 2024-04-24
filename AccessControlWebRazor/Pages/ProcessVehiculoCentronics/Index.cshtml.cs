using MediatR;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using AccessControlWebRazor.Pages.Shared;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.ProcessVehiculoCentronics
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
        public List<ProcesamientoVehiculoExterno> VehiculoCentronicsModel = new List<ProcesamientoVehiculoExterno>();
        public List<CentroCosto> CentroCostos { get; set; }

        public async Task OnGetAsync(List<ProcesamientoVehiculoExterno> VehiculoCentronics)
        {
            if (VehiculoCentronics.Count == 0)
            {
                VehiculoCentronicsModel = await _mediator.Send(new GetProcessVehiculoExtByCentroCostoQuery(0));

                foreach (var vehiculo in VehiculoCentronicsModel)
                {
                    // Verifica si la propiedad Modificado es nula
                    vehiculo.Dominio ??= "";
                    vehiculo.CentroCostoDesc ??= "";
                    vehiculo.EstadoFichado ??= "";
                    vehiculo.Fecha ??= "";
                    vehiculo.HoraIngreso ??= "";
                    vehiculo.HoraEgreso ??= "";
                    vehiculo.TotalHoras ??= "";
                }
            }
            else
            {
                VehiculoCentronicsModel = VehiculoCentronics;
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

            var query = new GetProcessVehiExterByFilterQuery(SearchModel.Filter, desde, hasta);

            var result = await _mediator.Send(query);
            var listaDepurada = result.Where(x=> x.CentroCostoID == 0).ToList();

            await OnGetAsync(listaDepurada);
            return Page();
        }

    }
}
