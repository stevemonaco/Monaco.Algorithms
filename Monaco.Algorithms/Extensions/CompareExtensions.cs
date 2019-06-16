using System;
using System.Linq;

namespace Monaco.Algorithms.Extensions
{
    public static class CompareExtensions
    {
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
                return min;
            else if (value.CompareTo(max) > 0)
                return max;
            else
                return value;
        }

        public static bool EqualsAny<T>(this T value, params T[] checks) where T : IEquatable<T>
        {
            return checks.Any(x => x.Equals(value));
        }
    }
}
