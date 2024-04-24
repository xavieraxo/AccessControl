using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CertronicModule.Command;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using MediatR;


namespace AccessControlWebRazor.Modules.CertronicModule.Handler
{
    public class CreateMaquinariaCommandHandler : IRequestHandler<CreateMaquinariaCommand, Maquinaria>
    {
        private readonly ICertronicService _certronicService;

        public CreateMaquinariaCommandHandler(ICertronicService certronicService)
        {
            _certronicService = certronicService;
        }
        public Task<Maquinaria> Handle(CreateMaquinariaCommand request, CancellationToken cancellationToken)
        {
            var result = _certronicService.CreateMaquinaria(request.Maquinaria);
            return Task.FromResult(result);
        }
    }
}
