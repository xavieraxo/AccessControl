namespace AccessControlWebRazor.HikVisionIntegration
{
    public class ResultHC
    {
        bool success = false;
        string successMessage = "";
        string errorMessage = "";
        string errorNumber = "";


        public bool Success
        {
            get { return success; }
            set { lock (this) { success = value; } }
        }

        public string SuccessMessage
        {
            get { return successMessage; }
            set { lock (this) { successMessage = value; } }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { lock (this) { errorMessage = value; } }
        }

        public string ErrorNumber
        {
            get { return errorNumber; }
            set { lock (this) { errorNumber = value; } }
        }
    }
}