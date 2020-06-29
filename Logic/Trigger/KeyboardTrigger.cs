using System.Collections;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Trigger.TriggerState;

namespace InputTweaker.Logic.Trigger
{
    public class KeyboardTrigger
    {
        private readonly KeyboardHook _hook;
        
        public KeyboardTrigger(KeyboardTriggerState triggerState, Queue actionQueue)
        {
            _hook = new KeyboardHook(KeyboardFilter.All, (ref KeyStroke keyStroke) =>
            {
                if (keyStroke.Code == triggerState.KeyCode && triggerState.MatchesPressed(keyStroke.State))
                {
                    Queue newActionQueue = (Queue) actionQueue.Clone();
                    ActionBase firstAction = (ActionBase) newActionQueue.Dequeue();
                    
                    firstAction.Execute(newActionQueue, true);
                }
            });
        }

        public void Cleanup()
        {
            _hook.Dispose();
        }
    }
}