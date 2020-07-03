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
            MouseFilter filter;
            bool success;
            
            switch (triggerState.TriggerOn)
            {
                case TriggerOn.Down:
                    success = MouseButtonHelper.ParseMouseButtonToMouseFilter(triggerState.Button, true, out filter);
                    break;
                case TriggerOn.Up:
                    success = MouseButtonHelper.ParseMouseButtonToMouseFilter(triggerState.Button, false, out filter);
                    break;
                case TriggerOn.Both:
                    MouseFilter down;
                    MouseFilter up;
                    success = MouseButtonHelper.ParseMouseButtonToMouseFilter(triggerState.Button, true, out down);
                    if (!success)
                    {
                        return;
                    }
                    success = MouseButtonHelper.ParseMouseButtonToMouseFilter(triggerState.Button, false, out up);
                    filter = (down | up);
                    break;
                case TriggerOn.None:
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (!success)
            {
                return;
            }
            
            _hook = new MouseHook(filter, (ref MouseStroke mouseStroke) =>
            {
                action.Execute(MouseButtonHelper.IsButtonDown(mouseStroke.State));

                if (triggerState.Block)
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