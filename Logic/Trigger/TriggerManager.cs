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
        private static readonly List<KeyboardTrigger> KeyboardTriggers = new List<KeyboardTrigger>();
        
        public static void Initialize()
        {
            if (InputInterceptorWrapper.Instance.Initialize())
            {
                Dictionary<TriggerType, Dictionary<ITriggerState, Queue>> triggerToActionMap =
                    (Dictionary<TriggerType, Dictionary<ITriggerState, Queue>>)
                    SettingsHandler.GetSetting(SettingKey.TriggerActionMap);

                foreach (KeyValuePair<TriggerType, Dictionary<ITriggerState, Queue>> triggerTypeSet in triggerToActionMap)
                {
                    switch (triggerTypeSet.Key)
                    {
                        case TriggerType.Keyboard:
                            Dictionary<ITriggerState, Queue> triggerStateToActionQueueMap = triggerTypeSet.Value;

                            foreach (KeyValuePair<ITriggerState,Queue> triggerStateToActionSet in triggerStateToActionQueueMap)
                            {
                                KeyboardTriggers.Add(new KeyboardTrigger((KeyboardTriggerState) triggerStateToActionSet.Key, triggerStateToActionSet.Value));
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
                foreach (KeyboardTrigger keyboardTrigger in KeyboardTriggers)
                {
                    keyboardTrigger.Cleanup();
                }
            }
        }
    }
}