using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Trigger.TriggerState;
using Nefarius.ViGEm.Client.Targets.Xbox360;

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
                    [new HardwareKeyboardTriggerState(KeyCode.W)] = 
                        new LogMessageAction("HardwareKeyboardTrigger")
                },
                [TriggerType.VirtualKeyboard] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new VirtualKeyboardTriggerState(Keys.Q)] =
                        new SplitBoolUpDownAction(
                            new LogMessageAction("down"), new LogMessageAction("up"))
                },
                [TriggerType.MouseButton] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new MouseButtonTriggerState(MouseButton.Left)] = 
                        new LogMessageAction("xbox",
                            100,
                            new ButtonPressXBoxAction(Xbox360Button.A))
                },
                [TriggerType.MouseScroll] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new MouseScrollTriggerState(MouseScroll.Vertical)] = 
                        new ActionBase()
                },
                [TriggerType.MouseMove] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new MouseMoveTriggerState(MouseAxis.X)] = 
                        new TransformDeltaToVirtualAxis(
                            "x",
                            10,
                            true,
                            new ModifyVirtualAxisExponentialAction(
                                "x", 
                                2.5f, 
                                true, 
                                new AxisMoveXBoxAction(Xbox360Axis.LeftThumbX,
                                    new LogInputAction())
                                )
                            )
                },
                [TriggerType.Timer] = new Dictionary<ITriggerState, ActionBase>
                {
                    [new TimerTriggerState(2000)] =
                        new ActionBase()
                }
            };
        }

        public static object GetSetting(SettingKey key)
        {
            return Settings.ContainsKey(key) ? Settings[key] : null;
        }
    }
}