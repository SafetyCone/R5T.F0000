﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.F0000;

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

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> items,
            IEnumerable<T> prependix)
        {
            return Instances.EnumerableOperator.Prepend(
                items,
                prependix);
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> items,
            params T[] prependix)
        {
            return Instances.EnumerableOperator.Prepend(
                items,
                prependix);
        }
    }
}

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

        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> enumerable,
            bool value,
            IEnumerable<T> appendix)
        {
            return Instances.EnumerableOperator.AppendIf(
                enumerable,
                value,
                appendix);
        }

        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> enumerable,
            bool value,
            params T[] appendices)
        {
            return Instances.EnumerableOperator.AppendIf(
                enumerable,
                value,
                appendices);
        }

        /// <summary>
        /// Delays execution of the appendix constructor until after the value is true.
        /// </summary>
        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> enumerable,
            bool value,
            params Func<T>[] appendixConstructors)
        {
            return Instances.EnumerableOperator.AppendIf(
                enumerable,
                value,
                appendixConstructors);
        }

        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> enumerable,
            bool value,
            IEnumerable<T> appendixIfTrue,
            IEnumerable<T> appendixIfFalse)
        {
            return Instances.EnumerableOperator.AppendIf(enumerable,
                value,
                appendixIfTrue,
                appendixIfFalse);
        }

        public static IEnumerable<T> AppendRange<T>(this IEnumerable<T> enumerable, IEnumerable<T> appendix)
        {
            return Instances.EnumerableOperator.AppendRange(enumerable, appendix);
        }

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

        /// <summary>
        /// A method for use when in an environment where a System.LINQ Except() method is avaiable.
        /// </summary>
        public static IEnumerable<T> Except2<T>(this IEnumerable<T> items, T item)
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

        /// <inheritdoc cref="IEnumerableOperator.ExceptLast{T}(IEnumerable{T}, int)"/>
        public static IEnumerable<T> ExceptLast<T>(this IEnumerable<T> enumerable, int numberOfElements)
        {
            var output = Instances.EnumerableOperator.ExceptLast(enumerable, numberOfElements);
            return output;
        }

        /// <inheritdoc cref="IEnumerableOperator.ExceptLast{T}(IEnumerable{T})"/>
        public static IEnumerable<T> ExceptLast<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.ExceptLast(enumerable);
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

        public static T Second<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.Second(enumerable);
            return output;
        }

        public static T SecondOrDefault<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.SecondOrDefault(enumerable);
            return output;
        }

        public static IEnumerable<T> OrderAlphabetically<T>(this IEnumerable<T> items,
            Func<T, string> keySelector)
        {
            var output = Instances.EnumerableOperator.OrderAlphabetically(items, keySelector);
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

        public static IEnumerable<T> SkipFirst<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.SkipFirst(enumerable);
            return output;
        }

        public static bool StartsWith<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> start,
            IEqualityComparer<T> equalityComparer)
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
