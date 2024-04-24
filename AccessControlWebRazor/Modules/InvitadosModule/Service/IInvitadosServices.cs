using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.InvitadosModule.Service
{
    public interface IInvitadosServices
    {
        Invitado CreateInvitado(Invitado invitado);
        Invitado UpdateInvitado(Invitado invitado);
        void DeleteInvitado(int Id);
        Invitado GetInvitadoByID(int Id);
        List<Invitado> GetAllInvitado();
        Invitado GetInvitadoByDNI(string DNI);
    }
}
