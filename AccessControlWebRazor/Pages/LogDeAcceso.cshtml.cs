using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccessControlWebRazor.Models;
using MediatR;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries;
using AccessControlWebRazor.Pages.Shared;
using AccessControlWebRazor.Services;
using AccessControlWebRazor.HikVisionIntegration;
using System.Runtime.CompilerServices;
using AccessControlWebRazor.Modules.VehiculosModule.Queries;
using AccessControlWebRazor.Modules.CertronicModule.Queries;

namespace AccessControlWebRazor.Pages
{

    public class LogDeAccesoModel : PageModel
    {
        private readonly IMediator _mediator;
        public LogDeAccesoModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [BindProperty]
        public SearchViewModel SearchModel { get; set; }
        public IList<LecturasGaritaLog> LecturasGaritaLog { get; set; } = default!;


        public async Task OnGetAsync(List<LecturasGaritaLog> LecturasGarita)
        {         


            if (LecturasGarita.Count == 0)
            {

                var lecturas = await _mediator.Send(new GetLecturasGaritaDelDiaQuery());

                if (lecturas.Count > 0)
                {
                    LecturasGaritaLog = lecturas.ToList();

                    foreach (var lectura in LecturasGaritaLog)
                    {
                        // Verifica si la propiedad Modificado es nula
                        lectura.Apellido ??= "";
                        lectura.Nombre ??= "";
                        lectura.DNI ??= "";
                        lectura.Genero ??= "";
                        lectura.TipoEjemplar ??= "";
                        lectura.FechaNacimiento ??= "";
                        lectura.FechaVencimiento ??= "";
                        lectura.NumeroExtraCuit ??= "";
                        lectura.Observaciones ??= "";
                        lectura.EstadoLectura ??= "";
                        lectura.FechaLectura ??= DateTime.Now;

                    }
                }
                else
                {
                    LecturasGaritaLog = new List<LecturasGaritaLog>();
                }
            }
            else
            {
                LecturasGaritaLog = LecturasGarita;
            }
        }

        public async Task<IActionResult> OnPostOpenDoor()
        {
            var result = await _mediator.Send(new GetLecturasGaritaDelDiaQuery());
            await OnGetAsync(result.Where(x => x.Procesado == 0).ToList());
            return Page();
        }

        public async Task<IActionResult> OnPostCloseDoor()
        {
            var result = await _mediator.Send(new GetLecturasGaritaDelDiaQuery());
            await OnGetAsync(result.Where(x => x.Procesado == 0).ToList());
            return Page();
        }

        public async Task<IActionResult> OnPostProcessAll()
        {
            var result = await _mediator.Send(new GetLecturasGaritaDelDiaQuery());
            await OnGetAsync(result.Where(x => x.Procesado == 0).ToList());
            return Page();
        }
        public async Task<IActionResult> OnPostSearch()
        {
            var query = new GetLecturaGaritasLogByFilterQuery(SearchModel.Filter, null, null);
            var result = await _mediator.Send(query);
            await OnGetAsync(result);
            return Page();

        }
        public async Task<IActionResult> OnPostSincronizarCamaras()
        {
            try
            {
                var listaProdeng = await _mediator.Send(new GetAllVehiculoQuery());
                var listaExtenrnos = await _mediator.Send(new GetAllVehiculosExternosQuery());

            }
            catch (Exception e)
            {

                throw e;
            }
            var result = await _mediator.Send(new GetLecturasGaritaDelDiaQuery());
            await OnGetAsync(result.Where(x => x.Procesado == 0).ToList());
            return Page();
        }

    }
}
