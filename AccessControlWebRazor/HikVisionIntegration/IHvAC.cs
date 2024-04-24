namespace AccessControlWebRazor.HikVisionIntegration
{
    public interface IHvAC
    {
        ResultHC InitHC();
        ResultHC Login();
        bool OperationDoor(int door, int action);
        void Close();

    }
}
