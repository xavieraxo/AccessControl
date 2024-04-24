using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlWebRazor.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetSessionInfo()
        {
            List<string> sessionInfo = new List<string>();
            return sessionInfo;

            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUserName)))
            {
                HttpContext.Session.SetString(SessionKeyEnum.SessionKeyUserName.ToString(), "Current User");
                HttpContext.Session.SetString(SessionKeyEnum.SessionKeySessionId.ToString(), Guid.NewGuid().ToString());
            }
            var username = HttpContext.Session.GetString(SessionVariables.SessionKeyUserName);
            var sessionid = HttpContext.Session.GetString(SessionVariables.SessionKeySessionId);
            sessionInfo.Add(username);
            sessionInfo.Add(sessionid);

            return sessionInfo;
        }

    }

}
