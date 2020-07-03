using System.Windows.Forms;
using InputTweaker.Logic.Enum;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class VirtualKeyboardTriggerState : ITriggerState
    {
        public Keys Key { get; private set; }
        public TriggerOn TriggerOn { get; private set; }

        public VirtualKeyboardTriggerState(Keys key, TriggerOn triggerOn)
        {
            Key = key;
            TriggerOn = triggerOn;
        }
    }
}