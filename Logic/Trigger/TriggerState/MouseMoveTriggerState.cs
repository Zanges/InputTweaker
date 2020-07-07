using InputTweaker.Logic.Enum;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class MouseMoveTriggerState : ITriggerState
    {
        public MouseAxis Axis { get; private set; }

        public MouseMoveTriggerState(MouseAxis axis)
        {
            Axis = axis;
        }
    }
}