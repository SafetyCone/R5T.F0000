using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IEnumerableOperator : IFunctionalityMarker
	{
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