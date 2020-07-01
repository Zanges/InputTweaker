using System.Collections;

namespace InputTweaker.Logic.Trigger.TriggerToActionSet
{
    public class VirtualKeyboardTriggerActionSet
    {
        public VirtualKeyboardTrigger Trigger;
        public Queue ActionQueue;

        public VirtualKeyboardTriggerActionSet(VirtualKeyboardTrigger trigger, Queue actionQueue)
        {
            Trigger = trigger;
            ActionQueue = actionQueue;
        }
    }
}