using System.Windows.Forms;
using InputTweaker.Logic.Enum;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class VirtualKeyboardTriggerState : ITriggerState
    {
        public Keys Key { get; private set; }
        public TriggerOn TriggerOn { get; private set; }
        public bool Block { get; private set; }

        public VirtualKeyboardTriggerState(Keys key, TriggerOn triggerOn, bool block)
        {
            Key = key;
            TriggerOn = triggerOn;
            Block = block;
        }
    }
}