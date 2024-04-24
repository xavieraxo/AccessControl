using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Pages.Shared;
using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.Procesamiento
{
    //[Authorize]
    public class ListaProcesadosModel : PageModel
    {
        private readonly IMediator _mediator;

        public ListaProcesadosModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [BindProperty]
        public SearchViewModel SearchModel { get; set; }
        public IList<Models.Procesamiento> ProcesamientoModel { get; set; }


        public async Task OnGetAsync(List<Models.Procesamiento> procesamientos)
        {
            if (procesamientos.Count == 0)
            {
                ProcesamientoModel = await _mediator.Send(new GetAllProcesamientoDistincZeroQuery());

                foreach (var proceso in ProcesamientoModel)
                {
                    // Verifica si la propiedad Modificado es nula
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
            var listaDepurada = result.Where(x => x.CentroCosto > 0).ToList();

            await OnGetAsync(listaDepurada);
            return Page();

        }
        public async Task<IActionResult> OnPostExport()
        {
            var result = new List<Models.Procesamiento>();
            DateTime? desde = null;
            DateTime? hasta = null;
            if (SearchModel.StartDate != Convert.ToDateTime("1/1/0001 00:00:00") && SearchModel.EndDate != Convert.ToDateTime("1/1/0001 00:00:00"))
            {
                desde = SearchModel.StartDate;
                hasta = SearchModel.EndDate;
            }

            var query = new GetProcesamientoPersonalByFilterQuery(SearchModel.Filter, desde, hasta);

            result = await _mediator.Send(query);

            var excel = await _mediator.Send(new ExportExcelPersonalProcesamientoQuery(result));

            if (excel != null && excel.Length > 0)
            {
                return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ProcesamientosPersonalProdeng" + DateTime.Now.ToShortDateString() + ".xlsx");
            }
            else
            {
                await OnGetAsync(result);
                return Page();
            }
        }

    }

}

