using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Command
{
    public class UpdateProcessVehiculoProdengCommand : IRequest<ProcesamientoVehiculoProdeng>
    {
        public ProcesamientoVehiculoProdeng _procesamiento;

        public UpdateProcessVehiculoProdengCommand(ProcesamientoVehiculoProdeng procesamietnoV)
        {
            _procesamiento = procesamietnoV;
        }

    }
}
