using System.Windows.Forms;
using System.Windows.Input;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class VirtualKeyboardTriggerState : ITriggerState
    {
        public Keys Key { get; private set; }
        public bool Pressed { get; private set; }
        public bool Block { get; private set; }

        public VirtualKeyboardTriggerState(Keys key, bool pressed, bool block)
        {
            Key = key;
            Pressed = pressed;
            Block = block;
        }
    }
}