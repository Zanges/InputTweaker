using InputTweaker.Logic.Enum;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class MouseScrollTriggerState : ITriggerState
    {
        public MouseScroll Axis { get; private set; }
        public TriggerOn TriggerOn { get; private set; }
        public bool Block { get; private set; }

        public MouseScrollTriggerState(MouseScroll axis, TriggerOn triggerOn, bool block)
        {
            Axis = axis;
            TriggerOn = triggerOn;
            Block = block;
        }
    }
}