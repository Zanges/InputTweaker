using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Trigger.TriggerState;

namespace InputTweaker.Logic.Setting
{
    public static class SettingsHandler
    {
        private static readonly Dictionary<SettingKey, object> Settings = new Dictionary<SettingKey, object>();

        public static void Initialize()
        {
            Settings[SettingKey.LogUnrecognized] = false;
            
            Settings[SettingKey.TriggerActionMap] = new Dictionary<TriggerType, Dictionary<ITriggerState, ActionBase>>
            {
                [TriggerType.HardwareKeyboard] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new HardwareKeyboardTriggerState(KeyCode.W, TriggerOn.Both, false)] = 
                        new LogMessageAction("HardwareKeyboardTrigger")
                },
                [TriggerType.VirtualKeyboard] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new VirtualKeyboardTriggerState(Keys.Q, TriggerOn.Both, false)] =
                        new BranchAction(new List<ActionBase>
                        {
                            new LogInputAction(),
                            new LogMessageAction("branch 2", 
                                new BoolDecisionsAction(
                                    new LogMessageAction("true"), 
                                    new LogMessageAction("false")
                                    )
                                ),
                        })
                },
                [TriggerType.MouseButton] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new MouseButtonTriggerState(MouseButton.Left, TriggerOn.Both, true)] = 
                        new LogInputAction()
                },
                [TriggerType.MouseScroll] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new MouseScrollTriggerState(MouseScroll.Vertical, TriggerOn.Both, false)] = 
                        new LogInputAction()
                }
            };
        }

        public static object GetSetting(SettingKey key)
        {
            return Settings.ContainsKey(key) ? Settings[key] : null;
        }
    }
}