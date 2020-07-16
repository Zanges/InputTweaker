using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using InputInterceptorNS;
using InputTweaker.Logic.Helper;
using InputTweaker.Logic.Ui.Window;

namespace InputTweaker.Logic.Initialisation
{
    public sealed class InputInterceptorWrapper
    {
        public static readonly InputInterceptorWrapper Instance = new InputInterceptorWrapper(); // Singleton

        public bool IsReady { get; private set; }
        
        private InputInterceptorWrapper()
        {
            
        }

        public bool Initialize()
        {
            if (InputInterceptor.CheckDriverInstalled())
            {
                if (InputInterceptor.Initialize())
                {
                    IsReady = true;
                }
            }
            else
            {
                if (Install())
                {
                    Initialize();
                }
            }

            return IsReady;
        }

        public bool Install()
        {
            if (InputInterceptor.CheckDriverInstalled())
            {
                Messenger.Default.Send(new OpenGenericMessageWindowMessage("InputInterceptor Driver already Installed", "InputInterceptor Driver is already Installed"));
                return false;
            }

            if (InputInterceptor.CheckAdministratorRights())
            {
                if (InputInterceptor.InstallDriver())
                {
                    Messenger.Default.Send(new OpenGenericMessageWindowMessage("InputInterceptor Driver Installed", "Please Restart"));
                    return true;
                }

                Messenger.Default.Send(new OpenGenericMessageWindowMessage("InputInterceptor Driver Installation failed", "Please install manualy"));
                return true;
            }

            Messenger.Default.Send(new OpenGenericMessageWindowMessage("InputInterceptor Driver Installation needs Admin access", "Please restart this Program as Admin"));
            return false;
        }
    }
}