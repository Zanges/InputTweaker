using InputTweaker.Logic.Enum;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class MouseScrollTriggerState : ITriggerState
    {
        public MouseScroll Axis { get; private set; }
        public TriggerOn TriggerOn { get; private set; }

        public MouseScrollTriggerState(MouseScroll axis, TriggerOn triggerOn)
        {
            Axis = axis;
            TriggerOn = triggerOn;
        }
    }
}