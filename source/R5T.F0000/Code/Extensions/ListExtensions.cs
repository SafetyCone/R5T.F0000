using System;
using System.Collections.Generic;


using Instances = R5T.F0000.Instances;


namespace System
{
    public static class ListExtensions
    {
        public static void AddRange<T>(this IList<T> list,
            IEnumerable<T> items)
        {
            Instances.ListOperator.AddRange(list, items);
        }

        public static void AddRange<T>(this IList<T> list,
            params T[] items)
        {
            Instances.ListOperator.AddRange(list, items);
        }
    }
}
