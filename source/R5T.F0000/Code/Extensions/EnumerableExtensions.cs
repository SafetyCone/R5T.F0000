using System;
using System.Collections.Generic;

using Instances = R5T.F0000.Instances;


namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ExceptLast<T>(this IEnumerable<T> enumerable, int numberOfElements)
        {
            var output = Instances.EnumerableOperator.ExceptLast(enumerable, numberOfElements);
            return output;
        }

        public static IEnumerable<T> ExceptLast<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.ExceptLast(enumerable);
            return output;
        }

        public static bool None<T>(this IEnumerable<T> items)
        {
            var output = Instances.EnumerableOperator.None(items);
            return output;
        }

        public static T[] Now<T>(this IEnumerable<T> items)
        {
            var output = Instances.EnumerableOperator.Now(items);
            return output;
        }
    }
}
