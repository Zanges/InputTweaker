using System;
using System.Windows.Input;
using InputInterceptorNS;
using InputTweaker.Logic.Enum;

namespace InputTweaker.Logic.Helper
{
    public static class MouseHelper
    {
        public static bool IsButtonDown(MouseState mouseState)
        {
            return mouseState.ToString().Contains("Down");
        }
        
        public static bool IsScrollDown(short scroll)
        {
            return scroll < 0;
        }
        
        public static bool IsMoveDown(int movement)
        {
            return movement < 0;
        }

        public static bool ParseMouseStateToMouseButton(MouseState mouseState, out MouseButton mouseButton)
        {
            switch (mouseState)
            {
                case MouseState.LeftButtonDown: case MouseState.LeftButtonUp:
                    mouseButton = MouseButton.Left;
                    return true;
                case MouseState.MiddleButtonDown: case MouseState.MiddleButtonUp:
                    mouseButton = MouseButton.Middle;
                    return true;
                case MouseState.RightButtonDown: case MouseState.RightButtonUp:
                    mouseButton = MouseButton.Right;
                    return true;
                case MouseState.ExtraButton1Down: case MouseState.ExtraButton1Up:
                    mouseButton = MouseButton.XButton1;
                    return true;
                case MouseState.ExtraButton2Down: case MouseState.ExtraButton2Up:
                    mouseButton = MouseButton.XButton2;
                    return true;
                default:
                    mouseButton = MouseButton.Left;
                    return false;
            }
        }

        public static bool ParseMouseButtonToMouseState(MouseButton mouseButton, bool down, out MouseState mouseState)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    mouseState = down ? MouseState.LeftButtonDown : MouseState.LeftButtonUp;
                    return true;
                case MouseButton.Middle:
                    mouseState = down ? MouseState.MiddleButtonDown : MouseState.MiddleButtonUp;
                    return true;
                case MouseButton.Right:
                    mouseState = down ? MouseState.RightButtonDown : MouseState.RightButtonUp;
                    return true;
                case MouseButton.XButton1:
                    mouseState = down ? MouseState.ExtraButton1Down : MouseState.ExtraButton1Up;
                    return true;
                case MouseButton.XButton2:
                    mouseState = down ? MouseState.ExtraButton2Down : MouseState.ExtraButton2Up;
                    return true;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mouseButton), mouseButton, null);
            }
        }

        public static bool ParseMouseButtonToMouseFilter(MouseButton mouseButton, bool down, out MouseFilter mouseFilter)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    mouseFilter = down ? MouseFilter.LeftButtonDown : MouseFilter.LeftButtonUp;
                    return true;
                case MouseButton.Middle:
                    mouseFilter = down ? MouseFilter.MiddleButtonDown : MouseFilter.MiddleButtonUp;
                    return true;
                case MouseButton.Right:
                    mouseFilter = down ? MouseFilter.RightButtonDown : MouseFilter.RightButtonUp;
                    return true;
                case MouseButton.XButton1:
                    mouseFilter = down ? MouseFilter.ExtraButton1Down : MouseFilter.ExtraButton1Up;
                    return true;
                case MouseButton.XButton2:
                    mouseFilter = down ? MouseFilter.ExtraButton2Down : MouseFilter.ExtraButton2Up;
                    return true;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mouseButton), mouseButton, null);
            }
        }

        public static bool ParseMouseScrollToMouseFilter(MouseScroll mouseScroll, out MouseFilter mouseFilter)
        {
            switch (mouseScroll)
            {
                case MouseScroll.Horizontal:
                    mouseFilter = MouseFilter.ScrollHorizontal;
                    return true;
                case MouseScroll.Vertical:
                    mouseFilter = MouseFilter.ScrollVertical;
                    return true;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mouseScroll), mouseScroll, null);
            }
        }
    }
}