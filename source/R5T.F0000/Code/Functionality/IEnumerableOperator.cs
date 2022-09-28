using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IEnumerableOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Returns a new enumerable (does not clear the input enumerable, but provides a clean slate for future operations).
		/// </summary>
		public IEnumerable<T> Clear<T>(IEnumerable<T> enumerable)
        {
			var output = Enumerable.Empty<T>();
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
	}
}