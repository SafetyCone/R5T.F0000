using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Instances = R5T.F0000.Instances;


namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, IEnumerable<T> appendix)
        {
            return Instances.EnumerableOperator.Append(enumerable, appendix);
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, params T[] appendix)
        {
            return Instances.EnumerableOperator.Append(enumerable, appendix);
        }

        public static IEnumerable<T> AppendRange<T>(this IEnumerable<T> enumerable, IEnumerable<T> appendix)
        {
            return Instances.EnumerableOperator.AppendRange(enumerable, appendix);
        }

        public static IEnumerable<T> AppendRange<T>(this IEnumerable<T> enumerable, Func<IEnumerable<T>> appendix)
        {
            return Instances.EnumerableOperator.AppendRange(enumerable, appendix);
        }

        public static IEnumerable<T> Clear<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.Clear(enumerable);
            return output;
        }
        public static bool ContainsAll<T>(this IEnumerable<T> superset, IEnumerable<T> subset)
        {
            var output = Instances.EnumerableOperator.ContainsAll(superset, subset);
            return output;
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, T item)
            where T : IEquatable<T>
        {
            var output = Instances.EnumerableOperator.Except(items, item);
            return output;
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, T item, IEqualityComparer<T> equalityComparer)
        {
            var output = Instances.EnumerableOperator.Except(items, item, equalityComparer);
            return output;
        }

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

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            Instances.EnumerableOperator.ForEach(enumerable, action);
        }

        public static Task ForEach<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            return Instances.EnumerableOperator.ForEach(enumerable, action);
        }

        /// <inheritdoc cref="R5T.F0000.IEnumerableOperator.ForEach_WithCounter{T}(IEnumerable{T}, Action{T, int})"/>
        public static void ForEach_WithCounter<T>(this IEnumerable<T> enumerable, Action<T, int> action_WithCounter)
        {
            Instances.EnumerableOperator.ForEach_WithCounter(enumerable, action_WithCounter);
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

        public static IEnumerable<T> OrderAlphabetically<T>(this IEnumerable<T> items, Func<T, string> keySelector)
        {
            var output = Instances.EnumerableOperator.OrderAlphabetically(items, keySelector);
            return output;
        }

        public static IEnumerable<T> SkipFirst<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.SkipFirst(enumerable);
            return output;
        }

        public static IEnumerable<T> TakeFirst<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.TakeFirst(enumerable);
            return output;
        }
    }
}
