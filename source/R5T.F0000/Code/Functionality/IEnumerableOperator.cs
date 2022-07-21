using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IEnumerableOperator : IFunctionalityMarker
	{
		public bool None<T>(IEnumerable<T> items)
        {
			var any = items.Any();

			// None is not-any.
			var output = !any;
			return output;
        }
	}
}