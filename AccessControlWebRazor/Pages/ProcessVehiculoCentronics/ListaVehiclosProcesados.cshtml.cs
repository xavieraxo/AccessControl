using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Data;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using AccessControlWebRazor.Pages.Shared;
using Microsoft.AspNetCore.Authorization;

namespace AccessControlWebRazor.Pages.ProcessVehiculoCentronics
{
    //[Authorize]
    public class ListaVehiclosProcesadosModel : PageModel
    {
        private readonly IMediator _mediator;

        public ListaVehiclosProcesadosModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [BindProperty]
        public SearchViewModel SearchModel { get; set; }
        public List<ProcesamientoVehiculoExterno> ProcesamientoVehiculoExterno = new List<ProcesamientoVehiculoExterno>();

        public async Task OnGetAsync(List<ProcesamientoVehiculoExterno> ProcesamientoVehiculo)
        {
            if (ProcesamientoVehiculo.Count == 0)
            {
                ProcesamientoVehiculoExterno = await _mediator.Send(new GetProcessVehiculoExtByCostoNoZeroQuery());
                if (ProcesamientoVehiculoExterno.Count > 0)
                {
                    foreach (var vehiculo in ProcesamientoVehiculoExterno)
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
            }
            else
            {
                ProcesamientoVehiculoExterno = ProcesamientoVehiculo;
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

            var query = new GetProcessVehiExterByFilterQuery(SearchModel.Filter, desde, hasta);

            var result = await _mediator.Send(query);
            var listaDepurada = result.Where(x => x.CentroCostoID > 0).ToList();

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
            var result = new List<ProcesamientoVehiculoExterno>();

            var query = new GetProcessVehiExterByFilterQuery(SearchModel.Filter, desde, hasta);

            result = await _mediator.Send(query);
            var excel = await _mediator.Send(new ExportarProcessVehiExternoToExcelQuery(result));

            if (excel != null && excel.Length > 0)
            {
                return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ProcesamientosVehiculosExternos" + DateTime.Now.ToShortDateString() + ".xlsx");
            }
            else
            {
                await OnGetAsync(result);
                return Page();
            }
        }
    }
}
