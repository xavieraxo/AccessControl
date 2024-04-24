namespace AccessControlWebRazor
{
    public class SessionVariables
    {
        public const string SessionKeyUserName = "SessionKeyUserName";
        public const string SessionKeySessionId = "SessionKeySessionId";
        public const string SessionKeySessionPermision = "SessionKeySessionPermision";
    }
    public enum SessionKeyEnum
    {
        SessionKeyUserName = 0,
        SessionKeySessionId = 1,
        SessionKeySessionPermision = 2
    }
}
