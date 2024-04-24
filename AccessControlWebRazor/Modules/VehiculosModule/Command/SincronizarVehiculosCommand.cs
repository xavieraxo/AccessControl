using MediatR;

namespace AccessControlWebRazor.Modules.VehiculosModule.Command
{
    public class SincronizarVehiculosCommand : IRequest<bool>
    {
        public string Path { get; set; }

        public SincronizarVehiculosCommand(string path)
        {
            Path = path;
        }
    }
}
