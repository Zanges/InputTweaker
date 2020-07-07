using System;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Helper;
using InputTweaker.Logic.Trigger.TriggerState;

namespace InputTweaker.Logic.Trigger
{
    public class MouseButtonTrigger
    {
        private readonly MouseHook _hook;

        public MouseButtonTrigger(MouseButtonTriggerState triggerState, ActionBase action)
        {
            bool success = MouseHelper.ParseMouseButtonToMouseFilter(triggerState.Button, out MouseFilter filter);
            if (!success)
            {
                return;
            }

            _hook = new MouseHook(filter, (ref MouseStroke mouseStroke) =>
            {
                if (action.Execute(MouseHelper.IsButtonDown(mouseStroke.State)))
                {
                    mouseStroke = new MouseStroke();
                }
            });
        }

        public void Cleanup()
        {
            _hook.Dispose();
        }
    }
}