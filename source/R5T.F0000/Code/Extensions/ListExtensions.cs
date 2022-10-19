using System;
using System.Collections.Generic;

using R5T.F0000;

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

        public static WasFound<T> HasNth<T>(this IList<T> list, int n)
        {
            var output = Instances.ListOperator.HasNth(list, n);
            return output;
        }

        public static T Nth<T>(this IList<T> list, int n)
        {
            var output = Instances.ListOperator.Nth(list, n);
            return output;
        }

        public static T NthOrDefault<T>(this IList<T> list, int n)
        {
            var output = Instances.ListOperator.NthOrDefault(list, n);
            return output;
        }

        public static WasFound<T> HasSecond<T>(this IList<T> list)
        {
            var output = Instances.ListOperator.HasSecond(list);
            return output;
        }

        public static T Second<T>(this IList<T> list)
        {
            var output = Instances.ListOperator.Second(list);
            return output;
        }

        public static T SecondOrDefault<T>(this IList<T> list)
        {
            var output = Instances.ListOperator.SecondOrDefault(list);
            return output;
        }
    }
}
