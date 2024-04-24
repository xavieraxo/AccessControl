using AccessControlWebRazor.DTO_s.LogInDTO_s;
using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.LogInModule.Queries
{
    public class LogInQuery : IRequest<LogInResponse>
    {
        public string User { get; set; }
        public string Password { get; set; }

        public LogInQuery(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
