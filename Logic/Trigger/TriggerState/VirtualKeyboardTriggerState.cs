using System.Windows.Forms;
using InputTweaker.Logic.Enum;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class VirtualKeyboardTriggerState : ITriggerState
    {
        public Keys Key { get; private set; }

        public VirtualKeyboardTriggerState(Keys key)
        {
            Key = key;
        }
    }
}