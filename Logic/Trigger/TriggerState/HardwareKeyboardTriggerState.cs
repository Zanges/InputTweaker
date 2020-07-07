using InputInterceptorNS;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Helper;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class HardwareKeyboardTriggerState : ITriggerState
    {
        public KeyCode KeyCode { get; private set; }

        public HardwareKeyboardTriggerState(KeyCode keyCode)
        {
            KeyCode = keyCode;
        }
    }
}