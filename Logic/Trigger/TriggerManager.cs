using System;
using System.Collections;
using System.Collections.Generic;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Initialisation;
using InputTweaker.Logic.Setting;

namespace InputTweaker.Logic.Trigger
{
    public static class TriggerManager
    {
        private static readonly List<KeyboardTrigger> KeyboardTriggers = new List<KeyboardTrigger>();
        
        public static void Initialize()
        {
            if (InputInterceptorWrapper.Instance.Initialize())
            {
                Dictionary<TriggerType, Dictionary<System.Enum, Queue>> triggerToActionMap =
                    (Dictionary<TriggerType, Dictionary<System.Enum, Queue>>)
                    SettingsHandler.GetSetting(SettingKey.TriggerActionMap);

                foreach (KeyValuePair<TriggerType, Dictionary<System.Enum, Queue>> triggerTypeSet in triggerToActionMap)
                {
                    switch (triggerTypeSet.Key)
                    {
                        case TriggerType.Keyboard:
                            foreach (KeyValuePair<System.Enum, Queue> keyToActionQueueSet in triggerTypeSet.Value)
                            {
                                KeyboardTriggers.Add(new KeyboardTrigger((KeyCode) keyToActionQueueSet.Key, keyToActionQueueSet.Value));
                            }
                            break;
                        
                        case TriggerType.Mouse:
                            throw new NotImplementedException();

                        case TriggerType.Serial:
                            throw new NotImplementedException();

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