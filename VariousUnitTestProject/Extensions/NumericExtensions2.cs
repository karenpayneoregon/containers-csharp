using System.Linq;

// ReSharper disable once CheckNamespace
namespace VariousUnitTestProject.Extensions2
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Anticipates null elements unlike other version
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool AllInt(this string[] sender) =>
            !sender
                .Any(string.IsNullOrWhiteSpace) && sender.SelectMany(item => item.ToCharArray())
                .All(@char => !string.IsNullOrWhiteSpace(@char.ToString()) && char.IsDigit(@char));

        public static bool HasNullValues(this string[] sender) => sender.Any(string.IsNullOrWhiteSpace);
    }
}