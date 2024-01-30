using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.F0000;
using R5T.L0089.T000;

using Framework = System.Collections.Generic;

using Instances = R5T.F0000.Instances;


namespace R5T.F0000.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> AlternateWith<T>(this IEnumerable<T> enumerable,
            T value)
        {
            return Instances.EnumerableOperator.AlternateWith(
                enumerable,
                value);
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable,
            Func<T> itemConstructor)
        {
            return Instances.EnumerableOperator.Append(enumerable, itemConstructor);
        }
    }
}

namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> AppendRange2<T>(this IEnumerable<T> enumerable, IEnumerable<T> appendix)
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

        /// <summary>
        /// A method for use when in an environment where a System.LINQ Except() method is avaiable.
        /// </summary>
        public static IEnumerable<T> Except2<T>(this IEnumerable<T> items, T item)
            where T : IEquatable<T>
        {
            var output = Instances.EnumerableOperator.Except(items, item);
            return output;
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, T item, Framework.IEqualityComparer<T> equalityComparer)
        {
            var output = Instances.EnumerableOperator.Except(items, item, equalityComparer);
            return output;
        }

        /// <inheritdoc cref="IEnumerableOperator.ExceptFirst{T}(IEnumerable{T}, int)"/>
        public static IEnumerable<T> ExceptFirst<T>(this IEnumerable<T> enumerable, int numberOfElements)
        {
            var output = Instances.EnumerableOperator.ExceptFirst(enumerable, numberOfElements);
            return output;
        }

        /// <inheritdoc cref="IEnumerableOperator.ExceptFirst{T}(IEnumerable{T})"/>
        public static IEnumerable<T> ExceptFirst<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.ExceptFirst(enumerable);
            return output;
        }

        public static IEnumerable<string> ExplicitNoneIfNone(this IEnumerable<string> strings)
        {
            var output = Instances.EnumerableOperator.ExplicitNoneIfNone(strings);
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

        /// <inheritdoc cref="IEnumerableOperator.ForEach_WithCounter{T}(IEnumerable{T}, Action{T, int})"/>
        public static void ForEach_WithCounter<T>(this IEnumerable<T> enumerable, Action<T, int> action_WithCounter)
        {
            Instances.EnumerableOperator.ForEach_WithCounter(enumerable, action_WithCounter);
        }

        public static WasFound<T> HasNth<T>(this IEnumerable<T> items, int n)
        {
            var output = Instances.EnumerableOperator.HasNth(items, n);
            return output;
        }

        public static T Nth<T>(this IEnumerable<T> items, int n)
        {
            var output = Instances.EnumerableOperator.Nth(items, n);
            return output;
        }

        public static T NthOrDefault<T>(this IEnumerable<T> items, int n)
        {
            var output = Instances.EnumerableOperator.NthOrDefault(items, n);
            return output;
        }

        public static WasFound<T> HasSecond<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.HasSecond(enumerable);
            return output;
        }

        public static T SecondOrDefault<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.SecondOrDefault(enumerable);
            return output;
        }

        public static IEnumerable<T> OrderAlphabetically_If<T>(this IEnumerable<T> items,
            Func<T, string> keySelector,
            bool orderAlphabetically)
        {
            var output = Instances.EnumerableOperator.OrderAlphabetically_If(items, keySelector, orderAlphabetically);
            return output;
        }

        public static IEnumerable<T> OrderAlphabetically2<T>(this IEnumerable<T> items, Func<T, string> keySelector)
        {
            var output = Instances.EnumerableOperator.OrderAlphabetically(items, keySelector);
            return output;
        }

        public static IEnumerable<T> OrderByNames<T>(this IEnumerable<T> items,
            Func<T, string> nameSelector,
            IEnumerable<string> orderedNames)
        {
            var output = OrderOperator.Instance.OrderByNames(
                items,
                nameSelector,
                orderedNames);

            return output;
        }

        public static IEnumerable<T> OrderByNames<T>(this IEnumerable<T> items,
            Func<T, string> nameSelector,
            params string[] orderedNames)
        {
            return items.OrderByNames(
                nameSelector,
                orderedNames.AsEnumerable());
        }

        public static bool StartsWith<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> start,
            Framework.IEqualityComparer<T> equalityComparer)
        {
            var output = Instances.EnumerableOperator.StartsWith(
                enumerable,
                start,
                equalityComparer);

            return output;
        }

        public static bool StartsWith<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> start)
        {
            var output = Instances.EnumerableOperator.StartsWith(
                enumerable,
                start);

            return output;
        }

        public static IEnumerable<T> TakeFirst<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.TakeFirst(enumerable);
            return output;
        }

        public static IEnumerable<T> TakeFirst2<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.TakeFirst(enumerable);
            return output;
        }

        public static IEnumerable<T> Transform<T>(this IEnumerable<T> enumerable,
            Func<IEnumerable<T>, IEnumerable<T>> transformer)
        {
            var output = EnumerableOperator.Instance.Transform(
                enumerable,
                transformer);

            return output;
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            var output = EnumerableOperator.Instance.ToDictionary(pairs);
            return output;
        }

        public static IEnumerable<(T1, T2)> ZipWithEqualLengthRequirement<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
        {
            return EnumerableOperator.Instance.ZipWithEqualLengthRequirement(first, second);
        }
    }
}
