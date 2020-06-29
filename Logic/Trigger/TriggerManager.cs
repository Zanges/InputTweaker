using System;
using System.Collections;
using System.Collections.Generic;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Initialisation;
using InputTweaker.Logic.Setting;
using InputTweaker.Logic.Trigger.TriggerState;

namespace InputTweaker.Logic.Trigger
{
    public static class TriggerManager
    {
        private static readonly List<HardwareKeyboardTrigger> HardwareKeyboardTriggers = new List<HardwareKeyboardTrigger>();
        private static readonly List<VirtualKeyboardTrigger> VirtualKeyboardTriggers = new List<VirtualKeyboardTrigger>();

        public static void Initialize()
        {
            if (InputInterceptorWrapper.Instance.Initialize())
            {
                Dictionary<TriggerType, Dictionary<ITriggerState, Queue>> triggerToActionMap =
                    (Dictionary<TriggerType, Dictionary<ITriggerState, Queue>>)
                    SettingsHandler.GetSetting(SettingKey.TriggerActionMap);

                foreach (KeyValuePair<TriggerType, Dictionary<ITriggerState, Queue>> triggerTypeSet in triggerToActionMap)
                {
                    Dictionary<ITriggerState, Queue> triggerStateToActionQueueMap = triggerTypeSet.Value;
                    
                    switch (triggerTypeSet.Key)
                    {
                        case TriggerType.HardwareKeyboard:
                            foreach (KeyValuePair<ITriggerState,Queue> triggerStateToActionSet in triggerStateToActionQueueMap)
                            {
                                HardwareKeyboardTriggers.Add(new HardwareKeyboardTrigger((HardwareKeyboardTriggerState) triggerStateToActionSet.Key, triggerStateToActionSet.Value));
                            }
                            break;
                        
                        case TriggerType.VirtualKeyboard:
                            foreach (KeyValuePair<ITriggerState,Queue> triggerStateToActionSet in triggerStateToActionQueueMap)
                            {
                                VirtualKeyboardTriggers.Add(new VirtualKeyboardTrigger((VirtualKeyboardTriggerState) triggerStateToActionSet.Key, triggerStateToActionSet.Value));
                            }

                            break;
                            
                        case TriggerType.Mouse:
                            throw new NotImplementedException();

                        case TriggerType.Serial:
                            throw new NotImplementedException();

                        case TriggerType.None:
                            break;
                        
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
        }
        
        public static void Cleanup()
        {
            if (InputInterceptorWrapper.Instance.IsReady)
            {
                foreach (HardwareKeyboardTrigger hardwareKeyboardTrigger in HardwareKeyboardTriggers)
                {
                    hardwareKeyboardTrigger.Cleanup();
                }
                HardwareKeyboardTriggers.Clear();
                
                foreach (VirtualKeyboardTrigger virtualKeyboardTrigger in VirtualKeyboardTriggers)
                {
                    virtualKeyboardTrigger.Cleanup();
                }
                VirtualKeyboardTriggers.Clear();
            }
        }

        public static void Reinitialize()
        {
            Cleanup();
            Initialize();
        }
    }
}