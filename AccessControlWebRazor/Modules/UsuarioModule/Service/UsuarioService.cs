using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.UsuarioModule.Data;
using System.Security.Cryptography;
using System.Text;

namespace AccessControlWebRazor.Modules.UsuarioModule.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario Createuser(Usuario user)
        {
            user.Password = ComputeSHA256Hash(user.Password);
            return _usuarioRepository.Insert(user);
        }

        public Usuario LogIn(string user, string password)
        {
            var usuarios = _usuarioRepository.GetAsync(x => x.User == user).Result;
            var usuarioCorrecto = usuarios.FirstOrDefault(x => x.Password == ComputeSHA256Hash(password));
            return usuarioCorrecto;
        }

        public Usuario ResetPassword(int userID)
        {
            var usuario = _usuarioRepository.GetById(userID);
            usuario.Password = ComputeSHA256Hash("123456");
            return _usuarioRepository.Update(usuario);
        }

        public Usuario GetUserByID(int ID)
        {
            return _usuarioRepository.GetById(ID);
        }

        public Usuario GetUserByPersonalID(int ID)
        {
            return _usuarioRepository.GetAsync(x=> x.PersonalID == ID).Result.FirstOrDefault();
        }

        public List<Usuario> GetAllUsers()
        {
            return _usuarioRepository.GetAll().ToList();
        }

        public List<Usuario> GetUsersByUsername(string user)
        {
            return _usuarioRepository.GetAsync(x=> x.User == user).Result.ToList();
        }

        private static string ComputeSHA256Hash(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public List<Usuario> GetUserByFilter(string filter)
        {
            var usuarios = _usuarioRepository.GetAsync(x => x.User.ToUpper().Trim().Contains(filter.ToUpper())
                                                        || x.PersonalID.Equals(filter)
                                                        || x.PermisoID.Equals(filter)).Result;
            return usuarios.ToList();
        }
    }
}
