using System;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Helper;
using InputTweaker.Logic.Trigger.TriggerState;

namespace InputTweaker.Logic.Trigger
{
    public class MouseScrollTrigger
    {
        private readonly MouseHook _hook;

        public MouseScrollTrigger(MouseScrollTriggerState triggerState, ActionBase action)
        {
            if (MouseHelper.ParseMouseScrollToMouseFilter(triggerState.Axis, out MouseFilter filter))
            {
                _hook = new MouseHook(filter, (ref MouseStroke mouseStroke) =>
                {
                    if (action.Execute(mouseStroke.Rolling))
                    {
                        mouseStroke = new MouseStroke();
                    }
                });
            }
        }

        public void Cleanup()
        {
            _hook.Dispose();
        }
    }
}