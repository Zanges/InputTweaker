using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Trigger;

namespace InputTweaker.Logic.Setting
{
    public static class SettingsHandler
    {
        private static readonly Dictionary<SettingKey, object> Settings = new Dictionary<SettingKey, object>();

        public static void Initialize()
        {
            Settings[SettingKey.LogUnrecognized] = false;
            
            Settings[SettingKey.TriggerActionMap] = new Dictionary<TriggerType, Dictionary<System.Enum, Queue>>
            {
                [TriggerType.Keyboard] = new Dictionary<System.Enum, Queue>
                {
                    [KeyCode.W] = new Queue(new []
                    {
                        new LogMessageAction(),
                    }),
                }
            };
        }

        public static object GetSetting(SettingKey key)
        {
            return Settings.ContainsKey(key) ? Settings[key] : null;
        }
    }
}