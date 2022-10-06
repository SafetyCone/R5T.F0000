using System;
using System.Collections.Generic;

using Instances = R5T.F0000.Instances;


namespace System
{
    public static class StringExtensions
    {
        public static IEnumerable<string> OrderAlphabetically(this IEnumerable<string> items)
        {
            var output = Instances.StringOperator.OrderAlphabetically(items);
            return output;
        }

        public static IEnumerable<string> OrderAlphabetically_OnlyIfDebug(this IEnumerable<string> items)
        {
            var output = Instances.StringOperator.OrderAlphabetically_OnlyIfDebug(items);
            return output;
        }
    }
}
