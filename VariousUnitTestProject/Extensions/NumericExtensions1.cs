using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace VariousUnitTestProject.Extensions1
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Poorly coded check to see if all elements can represent integers
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool AllInt(this string[] sender)
            => sender.SelectMany(item => item.ToCharArray()).All(char.IsNumber);

        /// <summary>
        /// Determine if array has any null elements
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>true if one or more null elements, false otherwise</returns>
        public static bool HasNullValues(this string[] sender) => sender.Any(string.IsNullOrWhiteSpace);
    }
}
