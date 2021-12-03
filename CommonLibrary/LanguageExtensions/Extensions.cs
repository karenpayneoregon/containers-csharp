using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.Classes;

namespace CommonLibrary.LanguageExtensions
{
    public static class Extensions
    {
        /// <summary>
        /// Convert bool to Yes or No
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToYesNoString(this bool source) => source ? "Yes" : "No";

        /// <summary>
        /// Determine if there are duplicates in source
        /// </summary>
        /// <typeparam name="T">inferred type</typeparam>
        /// <param name="source">IEnumerable</param>
        /// <returns>true if duplicates, false no duplicates</returns>
        /// <remarks>
        /// Alternate
        /// if(source.Count != source.Distinct().Count())
        /// </remarks>
        public static bool ContainsDuplicates<T>(this IEnumerable<T> source)
        {
            var knownKeys = new HashSet<T>();
            return source.Any(item => !knownKeys.Add(item));
        }

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

        /// <summary>
        /// Convert DataTable to List of T
        /// </summary>
        /// <typeparam name="TSource">Type to return from DataTable</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List of <see cref="TSource"/>Expected type list</returns>
        public static List<TSource> DataTableToList<TSource>(this DataTable table) where TSource : new()
        {
            List<TSource> list = new();

            var typeProperties = typeof(TSource).GetProperties().Select(propertyInfo => new
            {
                PropertyInfo = propertyInfo,
                Type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType
            }).ToList();

            foreach (var row in table.Rows.Cast<DataRow>())
            {

                TSource current = new();

                foreach (var typeProperty in typeProperties)
                {
                    object value = row[typeProperty.PropertyInfo.Name];
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    object safeValue = value is null || DBNull.Value.Equals(value) ? null : Convert.ChangeType(value, typeProperty.Type);
                    typeProperty.PropertyInfo.SetValue(current, safeValue, null);
                }

                list.Add(current);
            }

            return list;
        }
    }
}
