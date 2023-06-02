using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using R5T.F0000;

using Instances = R5T.F0000.Instances;


public static class StringExtensions
{
    public static bool IsNotNullAndNotEmpty(this string @string)
    {
        var isNotNullAndNotEmpty = Instances.StringOperator.IsNotNullAndNotEmpty(@string);
        return isNotNullAndNotEmpty;
    }
}


namespace System.Linq
{
    public static class StringExtensions
    {
        public static IEnumerable<string> ExceptIfEmpty(this IEnumerable<string> strings)
        {
            var output = strings
                .Where(StringOperator.Instance.IsNotEmpty)
                ;

            return output;
        }

        public static IEnumerable<string> OrderAlphabetically(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.OrderAlphabetically(strings);
            return output;
        }

        public static IEnumerable<string> OrderAlphabetically_OnlyIfDebug(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.OrderAlphabetically_OnlyIfDebug(strings);
            return output;
        }

        /// <inheritdoc cref="IStringOperator.Trim(string)"/>
        public static IEnumerable<string> Trim(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.Trim(strings);
            return output;
        }
    }
}


namespace R5T.F0000.Extensions
{
    public static class StringExtensions
    {
        public static string Join(this IEnumerable<string> strings)
        {
            var output = strings.Join(
                IStrings.Empty_Constant);

            return output;
        }

        public static string Join(this IEnumerable<string> strings,
            string separator)
        {
            return Instances.StringOperator.Join(
                separator,
                strings);
        }

        public static IEnumerable<string> MakeIntoLines(this IEnumerable<string> strings)
        {
            var output = strings
                .Select(Instances.StringOperator.MakeIntoLine)
                ;

            return output;
        }

        public static IEnumerable<string> Tabinate(this IEnumerable<string> strings)
        {
            return Instances.TextOperator.Tabinate(strings);
        }
    }
}
