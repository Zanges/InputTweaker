using System;
using System.Collections.Generic;
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
        private static readonly List<MouseButtonTrigger> MouseButtonTriggers = new List<MouseButtonTrigger>();
        private static readonly List<MouseScrollTrigger> MouseScrollTriggers = new List<MouseScrollTrigger>();
        private static readonly List<MouseMoveTrigger> mouseMoveTriggers = new List<MouseMoveTrigger>();

        public static void Initialize()
        {
            if (InputInterceptorWrapper.Instance.Initialize())
            {
                Dictionary<TriggerType, Dictionary<ITriggerState, ActionBase>> triggerToActionMap =
                    (Dictionary<TriggerType, Dictionary<ITriggerState, ActionBase>>)
                    SettingsHandler.GetSetting(SettingKey.TriggerActionMap);

                foreach (KeyValuePair<TriggerType, Dictionary<ITriggerState, ActionBase>> triggerTypeSet in triggerToActionMap)
                {
                    Dictionary<ITriggerState, ActionBase> triggerStateToActionQueueMap = triggerTypeSet.Value;
                    
                    switch (triggerTypeSet.Key)
                    {
                        case TriggerType.HardwareKeyboard:
                            foreach (KeyValuePair<ITriggerState, ActionBase> triggerStateToActionSet in triggerStateToActionQueueMap)
                            {
                                HardwareKeyboardTriggers.Add(new HardwareKeyboardTrigger((HardwareKeyboardTriggerState) triggerStateToActionSet.Key, triggerStateToActionSet.Value));
                            }
                            break;
                        
                        case TriggerType.VirtualKeyboard:
                            foreach (KeyValuePair<ITriggerState, ActionBase> triggerStateToActionSet in triggerStateToActionQueueMap)
                            {
                                VirtualKeyboardTriggers.Add(new VirtualKeyboardTrigger((VirtualKeyboardTriggerState) triggerStateToActionSet.Key, triggerStateToActionSet.Value));
                            }
                            break;
                            
                        case TriggerType.MouseButton:
                            foreach (KeyValuePair<ITriggerState, ActionBase> triggerStateToActionSet in triggerStateToActionQueueMap)
                            {
                                MouseButtonTriggers.Add(new MouseButtonTrigger((MouseButtonTriggerState) triggerStateToActionSet.Key, triggerStateToActionSet.Value));
                            }
                            break;
                        
                        case TriggerType.MouseScroll:
                            foreach (KeyValuePair<ITriggerState, ActionBase> triggerStateToActionSet in triggerStateToActionQueueMap)
                            {
                                MouseScrollTriggers.Add(new MouseScrollTrigger((MouseScrollTriggerState) triggerStateToActionSet.Key, triggerStateToActionSet.Value));
                            }
                            break;
                        
                        case TriggerType.MouseMove:
                            foreach (KeyValuePair<ITriggerState, ActionBase> triggerStateToActionSet in triggerStateToActionQueueMap)
                            {
                                mouseMoveTriggers.Add(new MouseMoveTrigger((MouseMoveTriggerState) triggerStateToActionSet.Key, triggerStateToActionSet.Value));
                            }
                            break;

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
                
                foreach (MouseButtonTrigger mouseButtonTrigger in MouseButtonTriggers)
                {
                    mouseButtonTrigger.Cleanup();
                }
                MouseButtonTriggers.Clear();
                
                foreach (MouseScrollTrigger mouseScrollTrigger in MouseScrollTriggers)
                {
                    mouseScrollTrigger.Cleanup();
                }
                MouseScrollTriggers.Clear();
                
                foreach (MouseMoveTrigger mouseMoveTrigger in mouseMoveTriggers)
                {
                    mouseMoveTrigger.Cleanup();
                }
                mouseMoveTriggers.Clear();
            }
        }

        public static void Reinitialize()
        {
            Cleanup();
            Initialize();
        }
    }
}