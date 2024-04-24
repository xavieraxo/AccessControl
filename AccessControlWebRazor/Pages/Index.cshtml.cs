using Microsoft.AspNetCore.Mvc.RazorPages;
using AccessControlWebRazor.Models;
using MediatR;


namespace AccessControlWebRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }


        public IList<LecturasGaritaLog> LecturasGaritaLog { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //var lecturas = await _mediator.Send(new GetAllLecturaGaritaLogQuery());

            //if (lecturas.Count() > 0)
            //{
            //    LecturasGaritaLog = lecturas.ToList();

            //    foreach (var lectura in LecturasGaritaLog)
            //    {
            //        // Verifica si la propiedad Modificado es nula
            //        lectura.Apellido ??= "";
            //        lectura.Nombre ??= "";
            //        lectura.DNI ??= "";
            //        lectura.Genero ??= "";
            //        lectura.TipoEjemplar ??= "";
            //        lectura.FechaNacimiento ??= "";
            //        lectura.FechaVencimiento ??= "";
            //        lectura.NumeroExtraCuit ??= "";
            //        lectura.Observaciones ??= "";
            //        lectura.EstadoLectura ??= "";
            //        lectura.FechaLectura ??= DateTime.Now;

            //    }
            //}
        }
    }
}
