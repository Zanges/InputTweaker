using System;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Helper;
using InputTweaker.Logic.Trigger.TriggerState;

namespace InputTweaker.Logic.Trigger
{
    public class MouseMoveTrigger
    {
        private readonly MouseHook _hook;

        public MouseMoveTrigger(MouseMoveTriggerState triggerState, ActionBase action)
        {
            _hook = new MouseHook(MouseFilter.Move, (ref MouseStroke mouseStroke) =>
            {
                int delta;
                switch (triggerState.Axis)
                {
                    case MouseAxis.X:
                        delta = mouseStroke.X;
                        break;
                    case MouseAxis.Y:
                        delta = mouseStroke.Y;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                if (delta != 0)
                {
                    if (triggerState.TriggerOn != TriggerOn.Both)
                    {
                        if (triggerState.TriggerOn == TriggerOn.Down)
                        {
                            if (!MouseHelper.IsMoveDown(delta))
                            {
                                return;
                            }
                        }
                        else if (MouseHelper.IsMoveDown(delta))
                        {
                            return;
                        }
                    }

                    if (action.Execute(delta))
                    {
                        mouseStroke = new MouseStroke();
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