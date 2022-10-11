using System;
using System.Collections.Generic;

using Instances = R5T.F0000.Instances;


namespace System.Linq
{
    public static class StringExtensions
    {
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

        public static IEnumerable<string> Trim(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.Trim(strings);
            return output;
        }
    }
}
