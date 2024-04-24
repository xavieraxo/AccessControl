namespace AccessControlWebRazor.HikVisionIntegration
{
    public class HvAC : IHvAC
    {
        public static int m_UserID = -1;

        public ResultHC InitHC()
        {
            ResultHC resultHC = new ResultHC();

            if (CHCNetSDK.NET_DVR_Init() == false)
            {
                System.Console.WriteLine("NET_DVR_Init error");
                resultHC.ErrorMessage = "NET_DVR_Init error";
                resultHC.Success = false;

                return resultHC;
            }

            CHCNetSDK.NET_DVR_SetLogToFile(3, "", false);

            resultHC.SuccessMessage = "NET_DVR_Init éxito";
            resultHC.Success = true;

            return resultHC;
        }

        public ResultHC Login()
        {
            ResultHC resultHC = new ResultHC();

            if (m_UserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout_V30(m_UserID);
                m_UserID = -1;
            }
            CHCNetSDK.NET_DVR_USER_LOGIN_INFO struLoginInfo = new CHCNetSDK.NET_DVR_USER_LOGIN_INFO();
            CHCNetSDK.NET_DVR_DEVICEINFO_V40 struDeviceInfoV40 = new CHCNetSDK.NET_DVR_DEVICEINFO_V40();
            struDeviceInfoV40.struDeviceV30.sSerialNumber = new byte[CHCNetSDK.SERIALNO_LEN];

            struLoginInfo.sDeviceAddress = "";
            struLoginInfo.sUserName = "";
            struLoginInfo.sPassword = "";
            ushort.TryParse("", out struLoginInfo.wPort);

            int lUserID = -1;
            lUserID = CHCNetSDK.NET_DVR_Login_V40(ref struLoginInfo, ref struDeviceInfoV40);

            if (lUserID >= 0)
            {
                m_UserID = lUserID;
                Console.WriteLine("Se inicio sesión con exito");
                resultHC.SuccessMessage = "Se inicio sesión con exito";
                resultHC.Success = true;
            }
            else
            {
                uint nErr = CHCNetSDK.NET_DVR_GetLastError();
                if (nErr == CHCNetSDK.NET_DVR_PASSWORD_ERROR)
                {
                    Console.WriteLine("Usuaro o contraseña invalidos");
                    resultHC.Success = false;
                    resultHC.ErrorMessage = "Usuaro o contraseña invalidos";
                    if (1 == struDeviceInfoV40.bySupportLock)
                    {
                        string strTemp1 = string.Format("Left {0} try opportunity", struDeviceInfoV40.byRetryLoginTime);
                        Console.WriteLine(strTemp1);
                    }
                }
                else if (nErr == CHCNetSDK.NET_DVR_USER_LOCKED)
                {
                    if (1 == struDeviceInfoV40.bySupportLock)
                    {
                        resultHC.Success = false;
                        string strTemp1 = string.Format("Usuario bloqueado, el tiempo restante de bloqueo es de {0}", struDeviceInfoV40.dwSurplusLockTime);
                        resultHC.ErrorMessage = strTemp1;
                        Console.WriteLine(strTemp1);
                    }
                }
                else
                {
                    resultHC.Success = false;
                    resultHC.ErrorMessage = "Error de red o el panel esta ocupado";
                    Console.WriteLine("Error de red o el panel esta ocupado");
                }
            }

            return resultHC;
        }

        public void Close()
        {
            if (m_UserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout_V30(m_UserID);
                m_UserID = -1;
            }
            CHCNetSDK.NET_DVR_Cleanup();

        }

        /*
         * action
         * 0 = Cerrar
         * 1 = Abrir
         * 2 = Mantener abierto
         * 3 = Mantener cerrado
         */
        public bool OperationDoor(int door, int action)
        {
            if (CHCNetSDK.NET_DVR_ControlGateway(m_UserID, door, (uint)action))
            {
                System.Console.WriteLine("NET_DVR_ControlGateway: Se ejecuto la instrucción corractamente");
                return true;
            }
            else
            {
                System.Console.WriteLine("NET_DVR_ControlGateway: Error al ejecutar instrucción: " + CHCNetSDK.NET_DVR_GetLastError());
                return false;
            }
        }
    }
}
