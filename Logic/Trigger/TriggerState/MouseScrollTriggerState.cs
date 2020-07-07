using InputTweaker.Logic.Enum;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class MouseScrollTriggerState : ITriggerState
    {
        public MouseScroll Axis { get; private set; }

        public MouseScrollTriggerState(MouseScroll axis)
        {
            Axis = axis;
        }
    }
}