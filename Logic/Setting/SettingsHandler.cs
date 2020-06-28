using System.Collections.Generic;
using System.Windows.Input;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Trigger;

namespace InputTweaker.Logic.Setting
{
    public static class SettingsHandler
    {
        private static readonly Dictionary<string, object> Settings = new Dictionary<string, object>();

        public static void Initialize()
        {
            Settings[SettingKey.LogUnrecognized.ToString()] = false;
            
            MouseTrigger.Instance.AddAction(MouseButton.Left, new LogMessageAction());
            MouseTrigger.Instance.AddAction(MouseButton.Left, new LogMessageAction());
            MouseTrigger.Instance.AddAction(MouseButton.Left, new LogMessageAction());
        }

        public static object GetSetting(string key)
        {
            return Settings.ContainsKey(key) ? Settings[key] : null;
        }
    }
}