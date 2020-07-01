using System.Collections;

namespace InputTweaker.Logic.Trigger.TriggerToActionSet
{
    public class HardwareKeyboardTriggerActionSet
    {
        public HardwareKeyboardTrigger Trigger;
        public Queue ActionQueue;

        public HardwareKeyboardTriggerActionSet(HardwareKeyboardTrigger trigger, Queue actionQueue)
        {
            Trigger = trigger;
            ActionQueue = actionQueue;
        }
    }
}