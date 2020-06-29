using System;
using InputInterceptorNS;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Initialisation;
using InputTweaker.Logic.Setting;
using InputTweaker.Logic.Ui.Common;

namespace InputTweaker.Logic.Trigger
{
    public class KeyboardTriggerOld
    {
        public static readonly KeyboardTriggerOld Instance = new KeyboardTriggerOld(); // Singleton

        private readonly LogWriter _logWriter = new LogWriter("Keyboard Input");
        private KeyboardHook _keyboardHook;

        private KeyboardTriggerOld()
        {
        }
        
        public void Initialize()
        {
            _keyboardHook = new KeyboardHook(KeyboardFilter.All, (ref KeyStroke keyStroke) =>
            {
                if ((bool) SettingsHandler.GetSetting(SettingKey.LogUnrecognized))
                {
                    _logWriter.LogMessage($"{keyStroke.Code} {keyStroke.State} {keyStroke.Information}");
                }
            });
        }

        public void Cleanup()
        {
            _keyboardHook.Dispose();
        }
    }
}