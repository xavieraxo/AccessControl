using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Command;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Service;
using AccessControlWebRazor.Modules.ProdengVehiculosModule.Service;
using MediatR;


namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Handler
{
    public class ProcessVehiculoProdengCommandHandler : IRequestHandler<ProcessVehiculoProdengCommand, ProcesamientoVehiculoProdeng>
    {
        private readonly IProcessVehiculoProdengService _processVehiculoProdengService;
        private readonly IVehiculoProdengService _vehiculoProdengService;

        public ProcessVehiculoProdengCommandHandler(IProcessVehiculoProdengService processVehiculoProdeng, IVehiculoProdengService vehiculoProdengService)
        {
            _processVehiculoProdengService = processVehiculoProdeng;            
            _vehiculoProdengService = vehiculoProdengService;
        }
        public Task<ProcesamientoVehiculoProdeng> Handle(ProcessVehiculoProdengCommand request, CancellationToken cancellationToken)
        {
            var vehiculoProdeng = _vehiculoProdengService.GetByDominio(request.LecturaPatente.Patente);
            
            if (request.LecturaPatente != null)
            {
                var procesamientoExterno = new ProcesamientoVehiculoProdeng()
                {
                  
                    CentroCostoId = 0,
                    EstadoFichado = "",
                    CentroCostoDesc = "",
                    Procesado = 0,
                    HoraIngreso = request.LecturaPatente.FechaLectura.ToString(),
                    HoraEgreso = "",
                    TotalHoras = "",
                };
                var result = _processVehiculoProdengService.InsertProcess(procesamientoExterno);
                return Task.FromResult(result);
            }
            else
            {
                var procesamiento = _processVehiculoProdengService.GetProcesamientoByVehiculoProdengId(request.Vehiculo.Id);
                procesamiento.HoraEgreso = request.LecturaPatente.FechaLectura.ToString();
                procesamiento.Procesado = 1;
                TimeSpan duracion = Convert.ToDateTime(request.LecturaPatente.FechaLectura.ToString()) - Convert.ToDateTime(procesamiento.HoraIngreso);
                double horasTotales = duracion.TotalHours;
                procesamiento.TotalHoras = horasTotales.ToString();

                _processVehiculoProdengService.UpdateProcess(procesamiento);
                return Task.FromResult(procesamiento);
            }
        }
    }
}
