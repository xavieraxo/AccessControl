using AccessControlWebRazor.DTO_s.LogInDTO_s;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.UsuarioModule.Service
{
    public interface IUsuarioService
    {
        Usuario LogIn(string user, string password);
        Usuario Createuser(Usuario user);
        Usuario GetUserByID(int ID);
        Usuario GetUserByPersonalID(int ID);
        Usuario ResetPassword(int userID);
        List<Usuario> GetAllUsers();
        List<Usuario> GetUsersByUsername(string user);
        List<Usuario> GetUserByFilter(string filter);
    }
}
