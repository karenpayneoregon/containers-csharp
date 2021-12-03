using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.Classes;

namespace CommonLibrary.LanguageExtensions
{
    public static class Extensions
    {
        public static string ToYesNoString(this bool value) => value ? "Yes" : "No";
        /// <summary>
        /// Add KeyValue pair if key does not already exists in Dictionary
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <remarks>Could return a bool</remarks>
        public static void AddSafe<TType>(this Dictionary<string, TType> dictionary, string key, TType value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
            }
        }

        /// <summary>
        /// Add KeyValue pair if key does not already exists in Dictionary
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <remarks>Could return a bool</remarks>        
        public static void AddSafe<TType>(this Dictionary<int, TType> dictionary, int key, TType value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
            }
        }

        /// <summary>
        /// Add KeyValue pair if key does not already exists in Dictionary
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <remarks>Could return a bool</remarks>        
        public static void AddSafe<TType>(this Dictionary<decimal, TType> dictionary, decimal key, TType value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
            }
        }

        /// <summary>
        /// Add KeyValue pair if key does not already exists in Dictionary
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <remarks>Could return a bool</remarks>        
        public static void AddSafe<TType>(this Dictionary<DateTime, TType> dictionary, DateTime key, TType value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
            }
        }

        public static IOrderedEnumerable<Car> Ordering(this IGrouping<string, Car> source)
            => source.OrderBy(item => item.Model).ThenBy(item => item.ProductionDate.Month).ThenBy(item => item.ProductionDate.Day);
    }
}
