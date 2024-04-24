using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Command;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Handler
{
    public class ProcesamientoVehiculoExternoCommandHandler : IRequestHandler<ProcesamientoVehiculoExternoCommand, ProcesamientoVehiculoExterno>
    {
        private readonly IProcesamientoVehiculoExternoService _procesamientoVehiculo;
        public ProcesamientoVehiculoExternoCommandHandler(IProcesamientoVehiculoExternoService procesamientoVehiculo)
        {
            _procesamientoVehiculo = procesamientoVehiculo;
        }
        public Task<ProcesamientoVehiculoExterno> Handle(ProcesamientoVehiculoExternoCommand request, CancellationToken cancellationToken)
        {
            var vehiculoProdeng = _procesamientoVehiculo.GetByDominio(request.Lectura.Patente);

            if (request.Lectura != null)
            {
                var procesamientoExterno = new ProcesamientoVehiculoExterno()
                {   
                    CentroCostoID = 0,
                    EstadoFichado = "",
                    CentroCostoDesc = "",
                    Procesado = 0,
                    HoraIngreso = request.Lectura.FechaLectura.ToString(),
                    HoraEgreso = "",
                    TotalHoras = "",
                };
                var result = _procesamientoVehiculo.InsertProcess(procesamientoExterno);
                return Task.FromResult(result);
            }
            else
            {
                var procesamiento = _procesamientoVehiculo.GetByVehicleId(request.Vehiculo.Id);
                procesamiento.HoraEgreso = request.Lectura.FechaLectura.ToString();
                procesamiento.Procesado = 1;
                TimeSpan duracion = Convert.ToDateTime(request.Lectura.FechaLectura.ToString()) - Convert.ToDateTime(procesamiento.HoraIngreso);
                double horasTotales = duracion.TotalHours;
                procesamiento.TotalHoras = horasTotales.ToString();

                _procesamientoVehiculo.UpdateProcesamiento(procesamiento);
                return Task.FromResult(procesamiento);
            }
        }
    }
}
