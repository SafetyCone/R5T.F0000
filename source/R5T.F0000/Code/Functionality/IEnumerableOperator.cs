using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.F0000;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IEnumerableOperator : IFunctionalityMarker
	{
		public IEnumerable<T> Append<T>(IEnumerable<T> enumerable, IEnumerable<T> appendix)
		{
			return enumerable.Concat(appendix);
		}

		public IEnumerable<T> Append<T>(IEnumerable<T> enumerable, params T[] appendix)
		{
			return enumerable.Concat(appendix);
		}

		public IEnumerable<T> AppendIf<T>(IEnumerable<T> enumerable,
			bool value,
			IEnumerable<T> appendixIfTrue,
			IEnumerable<T> appendixIfFalse)
		{
			var output = value
				? Instances.EnumerableOperator.Append(enumerable, appendixIfTrue)
				: Instances.EnumerableOperator.Append(enumerable, appendixIfFalse)
			;

			return output;
		}

		public IEnumerable<T> AppendRange<T>(IEnumerable<T> enumerable, IEnumerable<T> appendix)
		{
			return enumerable.Concat(appendix);
		}

		public IEnumerable<T> AppendRange<T>(IEnumerable<T> enumerable, Func<IEnumerable<T>> appendixGenerator)
		{
			var appendix = appendixGenerator();

			var output = this.AppendRange(enumerable, appendix);
			return output;
		}

		/// <summary>
		/// Returns a new enumerable (does not clear the input enumerable, but provides a clean slate for future operations).
		/// </summary>
		public IEnumerable<T> Clear<T>(IEnumerable<T> enumerable)
		{
			var output = Enumerable.Empty<T>();
			return output;
		}

		public bool ContainsAll<T>(IEnumerable<T> superset, IEnumerable<T> subset)
		{
			var output = subset.Except(superset).None();
			return output;
		}

		public IEnumerable<T> Empty<T>()
		{
			var output = Enumerable.Empty<T>();
			return output;
		}

		public IEnumerable<T> Except<T>(IEnumerable<T> items, T item)
			where T : IEquatable<T>
		{
			var output = items.Where(x => !x.Equals(item));
			return output;
		}

		public IEnumerable<T> Except<T>(IEnumerable<T> items, T item, IEqualityComparer<T> equalityComparer)
		{
			var output = items.Where(x => !equalityComparer.Equals(x, item));
			return output;
		}

		public IEnumerable<T> ExceptLast<T>(IEnumerable<T> enumerable, int numberOfElements)
		{
			// Use SkipLast().
			var output = enumerable.SkipLast(numberOfElements);
			return output;
		}

		public IEnumerable<T> ExceptLast<T>(IEnumerable<T> enumerable)
		{
			// Skip the last element.
			var output = this.ExceptLast(enumerable, 1);
			return output;
		}

		public void ForEach<T>(IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (var item in enumerable)
			{
				action(item);
			}
		}

		public async Task ForEach<T>(IEnumerable<T> enumerable, Func<T, Task> action)
		{
			foreach (var item in enumerable)
			{
				await action(item);
			}
		}

		/// <summary>
		/// Counter starts at one by default (unlike index, which starts at zero by default).
		/// </summary>
		public void ForEach_WithCounter<T>(IEnumerable<T> enumerable, Action<T, int> action_WithCounter)
		{
			var counter = 1;
			foreach (var item in enumerable)
			{
				action_WithCounter(item, counter);

				counter++;
			}
		}

		public IEnumerable<string> ExplicitNoneIfNone(IEnumerable<string> strings)
		{
			var any = strings.Any();

			if(any)
			{
				return strings;
			}
			else
			{
				return this.From(Values.Instance.ExplicitNone);
			}
		}

		public IEnumerable<T> From<T>(T instance)
		{
			yield return instance;
		}

        public IEnumerable<T> From<T>(params T[] instances)
        {
			foreach (var instance in instances)
			{
				yield return instance;
			}
        }

        public bool HasAny<T>(IEnumerable<T> items)
		{
			var output = items.Any();
			return output;
		}

		public bool None<T>(IEnumerable<T> items)
		{
			var any = items.Any();

			// None is not-any.
			var output = !any;
			return output;
		}

		/// <summary>
		/// Enumerates the enumerable.
		/// </summary>
		public T[] Now<T>(IEnumerable<T> items)
		{
			var output = items.ToArray();
			return output;
		}

		public WasFound<T> HasNth<T>(IEnumerable<T> items, int n)
		{
			var itemsEnumerator = items.GetEnumerator();
			for (int i = 0; i < n; i++)
			{
				var hasNext = itemsEnumerator.MoveNext();
				if (!hasNext)
				{
					return WasFound.NotFound<T>();
				}
			}

			var nth = itemsEnumerator.Current;

			return WasFound.Found(nth);
		}

		public T Nth<T>(IEnumerable<T> items, int n)
		{
			var wasFound = this.HasNth(items, n);
			if (!wasFound)
			{
				throw new InvalidOperationException($"Enumerable did not have an Nth (N = {n}) element.");
			}

			return wasFound.Result;
		}

		public T NthOrDefault<T>(IEnumerable<T> items, int n)
		{
			var wasFound = this.HasNth(items, n);

			var output = wasFound.ResultOrDefaultIfNotFound();
			return output;
		}

		public IEnumerable<T> OrderAlphabetically<T>(IEnumerable<T> items, Func<T, string> keySelector)
		{
			var output = items.OrderBy(keySelector);
			return output;
		}

		public WasFound<T> HasSecond<T>(IEnumerable<T> enumerable)
		{
			var output = this.HasNth(enumerable, 2);
			return output;
		}

		public T Second<T>(IEnumerable<T> enumerable)
		{
			var output = this.Nth(enumerable, 2);
			return output;
		}

		public T SecondOrDefault<T>(IEnumerable<T> enumerable)
		{
			var output = this.NthOrDefault(enumerable, 2);
			return output;
		}

		public IEnumerable<T> SkipFirst<T>(IEnumerable<T> enumerable)
		{
			var output = enumerable.Skip(1);
			return output;
		}

		public bool StartsWith<T>(
			IEnumerable<T> enumerable,
			IEnumerable<T> start,
			IEqualityComparer<T> equalityComparer)
		{
			var enumerableEnumeration = enumerable.GetEnumerator();
			var startEnumerator = start.GetEnumerator();

			while (startEnumerator.MoveNext())
			{
				var enumerableHasNext = enumerableEnumeration.MoveNext();
				if (!enumerableHasNext)
				{
					// Enumerable is too short.
					return false;
				}

				var enumerableCurrent = enumerableEnumeration.Current;
				var startCurrent = startEnumerator.Current;

				var currentIsEqual = equalityComparer.Equals(enumerableCurrent, startCurrent);
				if (!currentIsEqual)
				{
					return false;
				}
			}

			return true;
		}

		public bool StartsWith<T>(
			IEnumerable<T> enumerable,
			IEnumerable<T> start)
		{
			var equalityComparer = EqualityComparer<T>.Default;

			var output = this.StartsWith(
				enumerable,
				start,
				equalityComparer);

			return output;
		}

		public IEnumerable<T> TakeFirst<T>(IEnumerable<T> enumerable)
		{
			var output = enumerable.Take(1);
			return output;
		}

		public Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		{
			var output = pairs.ToDictionary(
				pair => pair.Key,
				pair => pair.Value);

			return output;
		}

		/// <summary>
		/// Zips two enumerable sequences together.
		/// If the two sequences are of unequal length, an exception is thrown.
		/// </summary>
		public IEnumerable<TResult> Zip_ThrowIfUnequalLengths<TFirst, TSecond, TResult>(
			IEnumerable<TFirst> first,
			IEnumerable<TSecond> second,
			Func<TFirst, TSecond, TResult> resultSelector)
		{
			var firstEnumerator = first.GetEnumerator();
			var secondEnumerator = second.GetEnumerator();

			var firstHasNext = firstEnumerator.MoveNext();
			var secondHasNext = secondEnumerator.MoveNext();

			while (firstHasNext)
			{
				if (!secondHasNext)
				{
					throw new Exception("First had more elements than the second.");
				}

				var result = resultSelector(firstEnumerator.Current, secondEnumerator.Current);
				yield return result;

				firstHasNext = firstEnumerator.MoveNext();
				secondHasNext = secondEnumerator.MoveNext();
			}

			if (secondHasNext)
			{
				throw new Exception("Second had more elements than the first.");
			}
		}

		/// <summary>
		/// Zips two enumerable sequences together.
		/// If the two sequences are of unequal length, no exception is thrown, and only the elements with a matching partner are zipped.
		/// </summary>
		public IEnumerable<TResult> Zip_OkIfUnequalLengths<TFirst, TSecond, TResult>(
			IEnumerable<TFirst> first,
			IEnumerable<TSecond> second,
			Func<TFirst, TSecond, TResult> resultSelector)
		{
			var firstEnumerator = first.GetEnumerator();
			var secondEnumerator = second.GetEnumerator();

			var firstHasNext = firstEnumerator.MoveNext();
			var secondHasNext = secondEnumerator.MoveNext();

			while (firstHasNext)
			{
				if (!secondHasNext)
				{
					break;
				}

				var result = resultSelector(firstEnumerator.Current, secondEnumerator.Current);
				yield return result;

				firstHasNext = firstEnumerator.MoveNext();
				secondHasNext = secondEnumerator.MoveNext();
			}
		}

		/// <summary>
		/// Chooses <see cref="Zip_OkIfUnequalLengths{TFirst, TSecond, TResult}(IEnumerable{TFirst}, IEnumerable{TSecond}, Func{TFirst, TSecond, TResult})"/> as the default to match the standard LINQ method behavior.
		/// </summary>
        public IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
            IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
			return this.Zip_OkIfUnequalLengths(first, second, resultSelector);
        }

		/// <summary>
		/// Zips two enumerable sequences together.
		/// If the two sequences are of unequal length, no exception is thrown, and only the elements with a matching partner are zipped.
		/// </summary>
		public IEnumerable<TResult> Zip_OkIfUnequalLengths<TFirst, TSecond, TResult>(
			IEnumerable<TFirst> first,
			IEnumerable<TSecond> second,
			Func<TFirst, TSecond, int, TResult> resultSelector)
		{
			var firstEnumerator = first.GetEnumerator();
			var secondEnumerator = second.GetEnumerator();

			var firstHasNext = firstEnumerator.MoveNext();
			var secondHasNext = secondEnumerator.MoveNext();

			int count = 0;
			while (firstHasNext)
			{
				if (!secondHasNext)
				{
					break;
				}

				var result = resultSelector(firstEnumerator.Current, secondEnumerator.Current, count++);
				yield return result;

				firstHasNext = firstEnumerator.MoveNext();
				secondHasNext = secondEnumerator.MoveNext();
			}
		}

		/// <summary>
		/// Chooses <see cref="Zip_OkIfUnequalLengths{TFirst, TSecond, TResult}(IEnumerable{TFirst}, IEnumerable{TSecond}, Func{TFirst, TSecond, int, TResult})"/> as the default to match the standard LINQ method behavior.
		/// </summary>
		public IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
			IEnumerable<TFirst> first,
			IEnumerable<TSecond> second,
			Func<TFirst, TSecond, int, TResult> resultSelector)
		{
			return this.Zip_OkIfUnequalLengths(first, second, resultSelector);
		}
	}
}