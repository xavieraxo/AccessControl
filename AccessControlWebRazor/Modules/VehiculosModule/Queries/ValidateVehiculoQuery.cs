using MediatR;

namespace AccessControlWebRazor.Modules.VehiculosModule.Queries
{
    public class ValidateVehiculoQuery : IRequest<bool>
    {
        public string Dominio { get; set; }
        public ValidateVehiculoQuery(string dominio)
        {
            Dominio = dominio;
        }
    }
}
