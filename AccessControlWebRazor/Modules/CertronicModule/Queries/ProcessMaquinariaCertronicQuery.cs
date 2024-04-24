using AccessControlWebRazor.DTO_s.CertronicDTO_s;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Queries
{
    public class ProcessMaquinariaCertronicQuery : IRequest<bool>
    {
        public MaquinariaDTO    Maquinaria { get; set; }

        public ProcessMaquinariaCertronicQuery(MaquinariaDTO maquinaria)
        {
            Maquinaria = maquinaria;
        }
    }
}
