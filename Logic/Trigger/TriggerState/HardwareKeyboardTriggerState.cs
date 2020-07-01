using InputInterceptorNS;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Helper;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class HardwareKeyboardTriggerState : ITriggerState
    {
        public KeyCode KeyCode { get; private set; }
        public TriggerOn TriggerOn { get; private set; }
        public bool Block { get; private set; }

        public HardwareKeyboardTriggerState(KeyCode keyCode, TriggerOn triggerOn, bool block)
        {
            KeyCode = keyCode;
            TriggerOn = triggerOn;
            Block = block;
        }

        public bool MatchesPressed(KeyState keyState)
        {
            if (TriggerOn == TriggerOn.Both)
            {
                return true;
            }

            bool triggerOnEqualsPressed = TriggerOn == TriggerOn.Down;
            
            return triggerOnEqualsPressed == KeyStateHelper.KeyStateToPressedBool(keyState);
        }
    }
}