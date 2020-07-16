namespace InputTweaker.Logic.Helper
{
    public static class MathHelper
    {
        public static T Clamp<T>(T value, T max, T min) // from: https://www.codeproject.com/Articles/23323/A-Generic-Clamp-Function-for-C
            where T : System.IComparable<T> {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        }
    }
}