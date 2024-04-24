using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.InvitadosModule.Data;

namespace AccessControlWebRazor.Modules.InvitadosModule.Service
{
    public class InvitadosService : IInvitadosServices
    {
        private readonly IInvitadosRepository _invitadosRepository;
        public InvitadosService(IInvitadosRepository invitadosRepository)
        {
            _invitadosRepository = invitadosRepository;
        }
        public Invitado CreateInvitado(Invitado invitado)
        {
            return _invitadosRepository.Insert(invitado);
        }

        public void DeleteInvitado(int Id)
        {
            _invitadosRepository.Delete(Id);
        }

        public List<Invitado> GetAllInvitado()
        {
            return _invitadosRepository.GetAll().ToList();
        }

        public Invitado GetInvitadoByDNI(string DNI)
        {
            return _invitadosRepository.GetAsync(x=> x.DNI == DNI).Result.FirstOrDefault();
        }

        public Invitado GetInvitadoByID(int Id)
        {
            return _invitadosRepository.GetById(Id);
        }

        public Invitado UpdateInvitado(Invitado invitado)
        {
            return _invitadosRepository.Update(invitado);
        }
    }
}
