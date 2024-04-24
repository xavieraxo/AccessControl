using AccessControlWebRazor.DTO_s.CertronicDTO_s;
using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Command
{
    public class CreateMaquinariaCommand : IRequest<Maquinaria>
    {
        public MaquinariaDTO Maquinaria { get; set; }

        public CreateMaquinariaCommand(MaquinariaDTO maquinaria)
        {
            Maquinaria = maquinaria; 
        }
    }
}
