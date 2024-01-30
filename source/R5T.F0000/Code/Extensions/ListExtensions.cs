using System;
using System.Collections.Generic;

using R5T.L0089.T000;

using Instances = R5T.F0000.Instances;


namespace System
{
    public static class ListExtensions
    {
        public static void AddRange<T>(this IList<T> list,
            IEnumerable<T> items)
        {
            Instances.ListOperator.Add_Range(list, items);
        }

        public static void AddRange<T>(this IList<T> list,
            params T[] items)
        {
            Instances.ListOperator.Add_Range(list, items);
        }

        public static WasFound<T> HasNth<T>(this IList<T> list, int n)
        {
            var output = Instances.ListOperator.HasNth(list, n);
            return output;
        }

        public static T Nth<T>(this IList<T> list, int n)
        {
            var output = Instances.ListOperator.Get_Nth(list, n);
            return output;
        }

        public static T NthOrDefault<T>(this IList<T> list, int n)
        {
            var output = Instances.ListOperator.Get_NthOrDefault(list, n);
            return output;
        }

        public static WasFound<T> HasSecond<T>(this IList<T> list)
        {
            var output = Instances.ListOperator.HasSecond(list);
            return output;
        }

        public static T Second<T>(this IList<T> list)
        {
            var output = Instances.ListOperator.Get_Second(list);
            return output;
        }

        public static T SecondOrDefault<T>(this IList<T> list)
        {
            var output = Instances.ListOperator.Get_SecondOrDefault(list);
            return output;
        }
    }
}


namespace R5T.F0000.Extensions
{
    public static class ListExtensions
    {
        /// <inheritdoc cref="L0066.IListOperator.Get_First{T}(IList{T})"/>
        public static T Get_First<T>(this IList<T> list)
        {
            return Instances.ListOperator.Get_First(list);
        }

        /// <inheritdoc cref="L0066.IListOperator.Get_Second{T}(IList{T})"/>
        public static T Get_Second<T>(this IList<T> list)
        {
            return Instances.ListOperator.Get_Second(list);
        }
    }
}
