using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Helper;
using InputTweaker.Logic.Trigger.TriggerState;

namespace InputTweaker.Logic.Trigger
{
    public class HardwareKeyboardTrigger
    {
        private readonly KeyboardHook _hook;

        public HardwareKeyboardTrigger(HardwareKeyboardTriggerState triggerState, ActionBase action)
        {
            _hook = new KeyboardHook(KeyboardFilter.All, (ref KeyStroke keyStroke) =>
            {
                if (keyStroke.Code == triggerState.KeyCode)
                {
                    if (action.Execute(KeyStateHelper.KeyStateToPressedBool(keyStroke.State)))
                    {
                        keyStroke =  new KeyStroke();
                    }
                }
            });
        }

        public void Cleanup()
        {
            _hook.Dispose();
        }
    }
}