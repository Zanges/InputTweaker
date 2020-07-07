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
        
        public MouseButtonTriggerState(MouseButton button)
        {
            Button = button;
        }

        public bool Match(MouseState mouseState)
        {
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