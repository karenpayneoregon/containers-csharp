﻿using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace CommonLibrary.LanguageExtensions
{
    /// <summary>
    /// Common string extensions 
    /// </summary>
    public static class NumericArrays
    {
        /// <summary>
        /// For any null element show a predefined value, defaults to (null)
        /// </summary>
        /// <param name="sender">array to act on</param>
        /// <param name="replacement">value to use for empty/null element</param>
        /// <returns>
        /// Comma delimited string
        /// </returns>
        public static string JoinWithNulls(this string[] sender, string replacement = "(empty)") => 
            string.Join(",",sender.Select(token => string.IsNullOrWhiteSpace(token) ? 
            replacement : 
            token).ToArray());

        public static string[] ToStringArray(this int?[] sender) => sender.Select(x => x.ToString()).ToArray();


        #region int convert methods

        /// <summary>
        /// Determine if all values can represent an int
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>true if all elements can be converted to int, false if not able to convert to int</returns>
        public static bool AllInt(this string[] sender) => 
            !sender
                .Any(string.IsNullOrWhiteSpace) && sender.SelectMany(item => item.ToCharArray())
                .All(@char => !string.IsNullOrWhiteSpace(@char.ToString()) && char.IsDigit(@char));

        /// <summary>
        /// Determine if all values are non-zero
        /// </summary>
        /// <param name="sender">string array of values</param>
        /// <returns>true if all elements are greater than 0, false otherwise</returns>
        public static bool NoZeros(this string[] sender)
            => sender.AsIntegerArray().All(value => value != 0);

        /// <summary>
        /// Given a string array, convert to a int array.
        /// If a element can not be converted the default value is 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>an int array where non-int values will be 0</returns>
        public static int[] AsIntegerArray(this string[] sender)
            => sender.ToIntegerArray();

        /// <summary>
        /// Convert values in array to int array discards non int values in array.
        /// </summary>
        /// <param name="sender">string array</param>
        /// <returns>All valid elements that are int discarding non int values</returns>
        public static int[] ToIntegerArray(this string[] sender)
        {

            var intArray = Array
                .ConvertAll(sender,
                    (input) => new
                    {
                        IsInteger = int.TryParse(input, out var integerValue),
                        Value = integerValue
                    })
                .Where(result => result.IsInteger)
                .Select(result => result.Value)
                .ToArray();

            return intArray;

        }
        /// <summary>
        /// Get all non-integer positions/indices 
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>indices for elements which can not be converted to int</returns>
        public static int[] GetNonIntegerIndexes(this string[] sender)
        {
            return sender.Select(
                (item, index) => int.TryParse(item, out  _ ) ?
                    new { IsInteger = true, Index = index } :
                    new { IsInteger = false, Index = index })
                .ToArray()
                .Where(item => item.IsInteger == false)
                .Select(item => item.Index).ToArray();
        }
        /// <summary>
        /// Convert all values in array to int array where non int values will be set to the default value.
        /// </summary>
        /// <param name="sender">string array</param>
        /// <returns>All elements in array as int</returns>
        public static int[] ToIntegerPreserveArray(this string[] sender) =>
            Array.ConvertAll(sender, (input) =>
            {
                int.TryParse(input, out var integerValue);
                return integerValue;
            });

        #endregion

        #region double convert methods
        /// <summary>
        /// Determine if all string elements can represent double
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool AllDouble(this string[] sender)
            => sender.All(item => double.TryParse(item, out _));


        /// <summary>
        /// Convert values in array to double array discards non double values in array.
        /// </summary>
        /// <param name="sender">string array</param>
        /// <returns>All valid elements that are double discarding non double values</returns>
        public static double[] ToDoubleArray(this string[] sender)
        {

            var doubleArray = Array
                .ConvertAll(sender,
                    (input) => new
                    {
                        IsDouble = double.TryParse(input, out var doubleValue),
                        Value = doubleValue
                    })
                .Where(result => result.IsDouble)
                .Select(result => result.Value)
                .ToArray();

            return doubleArray;

        }

        /// <summary>
        /// Convert all values in array to double array where non double values will be set to the default value.
        /// </summary>
        /// <param name="sender">string array</param>
        /// <returns>All elements in array as double</returns>
        public static double[] ToDoublePreserveArray(this string[] sender)
        {

            var doubleArray = Array.ConvertAll(sender, (input) =>
            {
                double.TryParse(input, out var doubleValue);
                return doubleValue;
            });

            return doubleArray;

        }

        /// <summary>
        /// Get all non-double indices
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static int[] GetNonDoubleIndexes(this string[] sender)
        {
            return sender.Select(
                    (item, index) => double.TryParse(item, out var tResult) ?
                        new { IsDouble = true, Index = index } :
                        new { IsDouble = false, Index = index })
                .ToArray()
                .Where(item => item.IsDouble == false).Select(item => item.Index)
                .ToArray();
        }

        #endregion


        #region decimal convert methods
        /// <summary>
        /// Determine if all string elements can represent decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool AllDecimal(this string[] sender)
            => sender.All(item => decimal.TryParse(item, out _));


        /// <summary>
        /// Convert values in array to decimal array discards non decimal values in array.
        /// </summary>
        /// <param name="sender">string array</param>
        /// <returns>All valid elements that are decimal discarding non decimal values</returns>
        public static decimal[] ToDecimalArray(this string[] sender)
        {

            var decimalArray = Array
                .ConvertAll(sender,
                    (input) => new
                    {
                        IsDecimal = decimal.TryParse(input, out var decimalValue),
                        Value = decimalValue
                    })
                .Where(result => result.IsDecimal)
                .Select(result => result.Value)
                .ToArray();

            return decimalArray;

        }
        /// <summary>
        /// Convert all values in array to decimal array where non decimal values will be set to the default value.
        /// </summary>
        /// <param name="sender">string array</param>
        /// <returns>All elements in array as decimal</returns>
        public static decimal[] ToDecimalPreserveArray(this string[] sender)
        {

            var decimalArray = Array.ConvertAll(sender, (input) =>
            {
                decimal.TryParse(input, out var decimalValue);
                return decimalValue;
            });

            return decimalArray;

        }
        /// <summary>
        /// Get all non-decimal indices
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static int[] GetNonDecimalIndexes(this string[] sender)
        {
            return sender.Select(
                    (item, index) => decimal.TryParse(item, out var tResult) ?
                        new { IsDecimal = true, Index = index } :
                        new { IsDecimal = false, Index = index })
                .ToArray()
                .Where(item => item.IsDecimal == false)
                .Select(item => item.Index).ToArray();
        }
        #endregion

        #region float convert methods
        /// <summary>
        /// Determine if all string elements can represent float
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool AllFloat(this string[] sender) =>
            sender.All(item => float.TryParse(item, out var test));

        /// <summary>
        /// Convert values in array to float array discards non float values in array.
        /// </summary>
        /// <param name="sender">string array</param>
        /// <returns>All valid elements that are float discarding non float values</returns>
        public static float[] ToFloatArray(this string[] sender)
        {

            var floatArray = Array
                .ConvertAll(sender,
                    (input) => new
                    {
                        IsFloat = float.TryParse(input, out var floatValue),
                        Value = floatValue
                    })
                .Where(result => result.IsFloat)
                .Select(result => result.Value)
                .ToArray();

            return floatArray;

        }
        /// <summary>
        /// Convert all values in array to float array where non float values will be set to the default value.
        /// </summary>
        /// <param name="sender">string array</param>
        /// <returns>All elements in array as float</returns>
        public static float[] ToFloatPreserveArray(this string[] sender)
        {

            var floatArray = Array.ConvertAll(sender, (input) =>
            {
                float.TryParse(input, out var floatValue);
                return floatValue;
            });

            return floatArray;

        }
        /// <summary>
        /// Get all non-float values
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static int[] GetNonFloatIndexes(this string[] sender)
        {
            return sender.Select(
                    (item, index) => float.TryParse(item, out var tResult) ?
                        new { IsFloat = true, Index = index } :
                        new { IsFloat = false, Index = index })
                .ToArray()
                .Where(item => item.IsFloat == false).Select(item => item.Index)
                .ToArray();
        }
        #endregion

    }
}
