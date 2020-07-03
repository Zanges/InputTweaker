using System;
using System.Windows.Input;
using InputInterceptorNS;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Helper;

namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class MouseButtonTriggerState : ITriggerState
    {
        public MouseButton Button { get; private set; }
        public TriggerOn TriggerOn { get; private set; }
        
        public MouseButtonTriggerState(MouseButton button, TriggerOn triggerOn)
        {
            Button = button;
            TriggerOn = triggerOn;
        }

        public bool Match(MouseState mouseState)
        {
            if (TriggerOn != TriggerOn.Both)
            {
                // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
                switch (TriggerOn)
                {
                    case TriggerOn.Down:
                        return !MouseButtonHelper.IsButtonDown(mouseState);
                    case TriggerOn.Up:
                        return MouseButtonHelper.IsButtonDown(mouseState);
                }
            }

            switch (Button)
            {
                case MouseButton.Left:
                    return mouseState == (MouseState.LeftButtonDown | MouseState.LeftButtonUp);
                case MouseButton.Middle:
                    return mouseState == (MouseState.MiddleButtonDown | MouseState.MiddleButtonUp);
                case MouseButton.Right:
                    return mouseState == (MouseState.RightButtonDown | MouseState.RightButtonUp);
                case MouseButton.XButton1:
                    return mouseState == (MouseState.ExtraButton1Down | MouseState.ExtraButton1Up);
                case MouseButton.XButton2:
                    return mouseState == (MouseState.ExtraButton2Down | MouseState.ExtraButton2Up);
                default:
                    return false;
            }
        }
    }
}