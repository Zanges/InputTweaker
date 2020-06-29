using InputInterceptorNS;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class HardwareKeyboardTriggerState : ITriggerState
    {
        public KeyCode KeyCode { get; private set; }
        public bool Pressed { get; private set; }
        public bool Block { get; private set; }

        public HardwareKeyboardTriggerState(KeyCode keyCode, bool pressed, bool block)
        {
            KeyCode = keyCode;
            Pressed = pressed;
            Block = block;
        }

        public bool MatchesPressed(KeyState keyState)
        {
            bool stateEqualsPressed = keyState == KeyState.Down || keyState == KeyState.E0;
            return Pressed == stateEqualsPressed;
        }
    }
}