using System;
using System.Collections;
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
                if (keyStroke.Code == triggerState.KeyCode && triggerState.MatchesPressed(keyStroke.State))
                {
                    if (triggerState.Block)
                    {
                        keyStroke =  new KeyStroke();
                    }
                    
                    action.Execute(KeyStateHelper.KeyStateToPressedBool(keyStroke.State));
                }
            });
        }

        public void Cleanup()
        {
            _hook.Dispose();
        }
    }
}