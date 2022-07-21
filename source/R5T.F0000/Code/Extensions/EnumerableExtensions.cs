using System;
using System.Collections.Generic;

using Instances = R5T.F0000.Instances;


namespace System
{
    public static class EnumerableExtensions
    {
        public static bool None<T>(this IEnumerable<T> items)
        {
            var output = Instances.EnumerableOperator.None(items);
            return output;
        }
    }
}
