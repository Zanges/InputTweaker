using InputInterceptorNS;

namespace InputTweaker.Logic.Helper
{
    public static class KeyStateHelper
    {
        public static bool KeyStateToPressedBool(KeyState keyState)
        {
            return keyState == KeyState.Down || keyState == (KeyState.E0 & ~KeyState.Up);
        }
    }
}