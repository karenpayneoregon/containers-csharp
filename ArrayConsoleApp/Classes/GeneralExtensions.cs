using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConsoleApp.Classes
{
    public static class GeneralExtensions
    {
        public static T[] SubArray<T>(this T[] sequence, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(sequence, offset, result, 0, length);
            return result;
        }
        public static bool In<T>(this T source, params T[] list)
        {
            if (null == source) throw new ArgumentNullException("source");

            return ((IList)list).Contains(source);

        }

        public static bool InCondition<T>(this T sender, params T[] values) => values.Contains(sender);

    }
}

