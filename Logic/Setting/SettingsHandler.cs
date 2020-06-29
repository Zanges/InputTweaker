using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Trigger;
using InputTweaker.Logic.Trigger.TriggerState;

namespace InputTweaker.Logic.Setting
{
    public static class SettingsHandler
    {
        private static readonly Dictionary<SettingKey, object> Settings = new Dictionary<SettingKey, object>();

        public static void Initialize()
        {
            Settings[SettingKey.LogUnrecognized] = false;
            
            Settings[SettingKey.TriggerActionMap] = new Dictionary<TriggerType, Dictionary<ITriggerState, Queue>>
            {
                [TriggerType.HardwareKeyboard] = new Dictionary<ITriggerState, Queue>
                {
                    [new HardwareKeyboardTriggerState(KeyCode.W, true, false)] = new Queue(new []
                    {
                        new LogMessageAction(),
                    }),
                },
                [TriggerType.VirtualKeyboard] = new Dictionary<ITriggerState, Queue>
                {
                    [new VirtualKeyboardTriggerState(Keys.W, true, false)] = new Queue(new []
                    {
                        new LogMessageAction(),
                    }),
                },
            };
        }

        public static object GetSetting(SettingKey key)
        {
            return Settings.ContainsKey(key) ? Settings[key] : null;
        }
    }
}