using System;
using InputInterceptorNS;
using InputTweaker.Logic.Trigger;

namespace InputTweaker.Logic.Initialisation
{
    public sealed class TriggerInitialisation
    {
        public static readonly TriggerInitialisation Instance = new TriggerInitialisation(); // Singleton

        private TriggerInitialisation()
        {
        }

        public void Initialize()
        {
            if (InputInterceptorWrapper.Instance.Initialize())
            {
                KeyboardTrigger.Instance.Initialize();
                MouseTrigger.Instance.Initialize();
            }
        }
        
        public void Cleanup()
        {
            if (InputInterceptorWrapper.Instance.IsReady)
            {
                KeyboardTrigger.Instance.Cleanup();
                MouseTrigger.Instance.Cleanup();
            }
        }
    }
}