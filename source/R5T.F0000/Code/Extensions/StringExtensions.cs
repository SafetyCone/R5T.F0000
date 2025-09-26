using System;
using System.Collections.Generic;
using System.Linq;

using R5T.F0000;

using Instances = R5T.F0000.Instances;


public static class StringExtensions
{
    public static bool IsNotNullAndNotEmpty(this string @string)
    {
        var isNotNullAndNotEmpty = Instances.StringOperator.Is_NotNullOrEmpty(@string);
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
    }
}


namespace R5T.F0000.Extensions
{
    public static class StringExtensions
    {
        public static char Get_First(this string @string)
        {
            return Instances.StringOperator.Get_First(@string);
        }

        public static char Get_Second(this string @string)
        {
            return Instances.StringOperator.Get_Second(@string);
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

        /// <inheritdoc cref="F10Y.L0000.IStringOperator.Trim_End(string, string)"/>
        public static string Trim_End(this string value,
            string ending)
        {
            return Instances.StringOperator.Trim_End(
                value,
                ending);
        }

        /// <inheritdoc cref="F10Y.L0000.IStringOperator.Trim_NewLines(string)"/>
        public static string Trim_NewLines(this string value)
        {
            return Instances.StringOperator.Trim_NewLines(value);
        }

        /// <inheritdoc cref="F10Y.L0000.IStringOperator.Trim_Start(string, string)"/>
        public static string Trim_Start(this string value,
            string beginning)
        {
            return Instances.StringOperator.Trim_Start(
                value,
                beginning);
        }
    }
}
