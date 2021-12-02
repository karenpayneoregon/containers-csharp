using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Classes.Generics
{
    public static class Extensions
    {
        /// <summary>
        /// Return a list given a <seealso cref="Range"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">T</param>
        /// <param name="range">Range to get list</param>
        /// <returns></returns>
        public static List<T> GetRange<T>(this List<T> list, Range range)
        {
            /*
             * Named value Tuple
             */
            (int start, int length) = range.GetOffsetAndLength(list.Count);

            return list.GetRange(start, length);

        }
    }
}
