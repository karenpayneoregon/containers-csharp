using System.Collections.Generic;
using System.Text.Json;

namespace CommonLibrary.Classes
{
    public static class JSonHelper
    {

        /// <summary>
        /// Convert a json string to a list of T
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="jsonString">Valid json</param>
        /// <returns>List&lt;T&gt;</returns>
        public static List<T> JSonToList<T>(this string jsonString) =>
            JsonSerializer.Deserialize<List<T>>(jsonString);
    }
}