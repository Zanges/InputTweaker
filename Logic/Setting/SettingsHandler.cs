﻿using System.Collections.Generic;
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
                    [new HardwareKeyboardTriggerState(KeyCode.W, TriggerOn.Both)] = 
                        new LogMessageAction("HardwareKeyboardTrigger")
                },
                [TriggerType.VirtualKeyboard] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new VirtualKeyboardTriggerState(Keys.Q, TriggerOn.Down)] =
                        new LogMessageAction("q")
                },
                [TriggerType.MouseButton] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new MouseButtonTriggerState(MouseButton.Right, TriggerOn.Both)] = 
                        new LogInputAction()
                },
                [TriggerType.MouseScroll] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new MouseScrollTriggerState(MouseScroll.Vertical, TriggerOn.Both)] = 
                        new BlockInputAction(new DeltaDecisionAction(
                            new LogMessageAction("up"), 
                            new LogMessageAction("down")
                            ))
                },
                [TriggerType.MouseMove] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new MouseMoveTriggerState(MouseAxis.X, TriggerOn.Both)] = 
                        new DeltaDecisionAction(
                            new ActionBase(),
                            new ActionBase()
                            )
                },
                [TriggerType.Timer] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new MouseButtonTriggerState(MouseButton.Left, TriggerOn.Both)] =
                        new LogMessageAction("TIMER")
                }
            };
        }

        public static object GetSetting(SettingKey key)
        {
            return Settings.ContainsKey(key) ? Settings[key] : null;
        }
    }
}