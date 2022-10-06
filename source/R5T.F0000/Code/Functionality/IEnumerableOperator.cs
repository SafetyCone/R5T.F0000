using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

		public IEnumerable<T> From<T>(T instance)
        {
			yield return instance;
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

		public IEnumerable<T> OrderAlphabetically<T>(IEnumerable<T> items, Func<T, string> keySelector)
		{
			var output = items.OrderBy(keySelector);
			return output;
		}

		public IEnumerable<T> SkipFirst<T>(IEnumerable<T> enumerable)
		{
			var output = enumerable.Skip(1);
			return output;
		}

		public IEnumerable<T> TakeFirst<T>(IEnumerable<T> enumerable)
		{
			var output = enumerable.Take(1);
			return output;
		}
	}
}