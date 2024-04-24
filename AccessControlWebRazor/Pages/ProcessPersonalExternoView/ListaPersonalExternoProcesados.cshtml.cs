using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using AccessControlWebRazor.Pages.Shared;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.ProcessPersonalExternoView
{
    //[Authorize]
    public class ListaPersonalExternoProcesadosModel : PageModel
    {
        private readonly IMediator _mediator;

        public ListaPersonalExternoProcesadosModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [BindProperty]
        public SearchViewModel SearchModel { get; set; }
        public List<ProcesamientoPersonalExterno> ProcesamientoPersonalExterno { get; set; }

        public async Task OnGetAsync(List<ProcesamientoPersonalExterno> procesamientos)
        {
            if (procesamientos.Count == 0)
            {
                ProcesamientoPersonalExterno = await _mediator.Send(new GetAllProcessPersExtByCentroCostoDistinctZeroQuery());

                foreach (var proceso in ProcesamientoPersonalExterno)
                {
                    proceso.DNI ??= "-";
                    proceso.HoraIngreso ??= "-";
                    proceso.HoraEgreso ??= "-";
                    proceso.TotalHoras ??= "-";
                    proceso.EstadoFichada ??= "-";
                    proceso.CentroCostoDesc ??= "-";
                    proceso.Fecha ??= "-";
                }
            }
            else
            {

                ProcesamientoPersonalExterno = procesamientos;
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

            var query = new GetProcessPersonalExternoByFilterQuery(SearchModel.Filter, desde, hasta);
            

            var result = await _mediator.Send(query);
            var listaDepurada = result.Where(x=> x.CentroCostoId > 0).ToList();
            await OnGetAsync(listaDepurada);
            return Page();
        }
        public async Task<IActionResult> OnPostExport()
        {
            DateTime? desde = null;
            DateTime? hasta = null;
            if (SearchModel.StartDate != Convert.ToDateTime("1/1/0001 00:00:00") && SearchModel.EndDate != Convert.ToDateTime("1/1/0001 00:00:00"))
            {
                desde = SearchModel.StartDate;
                hasta = SearchModel.EndDate;
            }
            var result = new List<ProcesamientoPersonalExterno>();
            var query = new GetProcessPersonalExternoByFilterQuery(SearchModel.Filter, desde, hasta);

            result = await _mediator.Send(query);
            var excel = await _mediator.Send(new ExportarExcelPersonalExternoQuery(result));

            if (result != null && excel.Length > 0)
            {
                return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ProcesamientosPersonalExterno" + DateTime.Now.ToShortDateString() + ".xlsx");
            }
            else
            {
                await OnGetAsync(result);
                return Page();
            }


        }


    }
}
