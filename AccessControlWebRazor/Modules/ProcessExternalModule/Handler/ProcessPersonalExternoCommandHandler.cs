using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CentroCostoModule.Service;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using AccessControlWebRazor.Modules.ProcessExternalModule.Command;
using AccessControlWebRazor.Modules.ProcessExternalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Handler
{
    public class ProcessPersonalExternoCommandHandler : IRequestHandler<ProcessPersonalExternoCommand, ProcesamientoPersonalExterno>
    {
        private readonly IProcesamientoPersonalExternoService _service;
        private readonly ICertronicService _certronicService;
        private readonly ICentroCostoService _costoService;

        public ProcessPersonalExternoCommandHandler(IProcesamientoPersonalExternoService procesamientoPersonalExternoService, ICertronicService certronicService, ICentroCostoService costoService)
        {
            _service = procesamientoPersonalExternoService;
            _certronicService = certronicService;            
            _costoService = costoService;
        }
        public Task<ProcesamientoPersonalExterno> Handle(ProcessPersonalExternoCommand request, CancellationToken cancellationToken)
        {
            var personalExterno = _certronicService.GetPersonalExternoByDNI(request.PersonalExterno.Dni);
            var procesamiento = _service.GetProcesamientoByPersonalId(personalExterno.Id);

            if (procesamiento == null)
            {
                var procesamientoExterno = new ProcesamientoPersonalExterno()
                {
                    DNI = personalExterno.Dni,
                    CentroCostoId = 0,
                    EstadoFichada = request.LecturaGaritaLog.EstadoLectura,
                    CentroCostoDesc = "",
                    PersonalExternoId = personalExterno.Id,
                    Procesado = 0,
                    HoraIngreso = request.LecturaGaritaLog.FechaLectura.ToString(),
                    HoraEgreso = "",
                    TotalHoras = "",
                };
                var result = _service.InsertProcess(procesamientoExterno);
                return Task.FromResult(result);
            }
            else
            {
                
                if (Convert.ToDateTime(procesamiento.HoraIngreso).AddHours(1) < Convert.ToDateTime(request.LecturaGaritaLog.FechaLectura))
                {
                    procesamiento.HoraEgreso = request.LecturaGaritaLog.FechaLectura.ToString();
                    procesamiento.Procesado = 1;
                    TimeSpan duracion = Convert.ToDateTime(request.LecturaGaritaLog.FechaLectura.ToString()) - Convert.ToDateTime(procesamiento.HoraIngreso);
                    double horasTotales = duracion.TotalHours;
                    procesamiento.TotalHoras = horasTotales.ToString();

                    _service.UpdateProcess(procesamiento);
                    return Task.FromResult(procesamiento);
                }
            }
            return Task.FromResult(procesamiento);
        }
    }
}
