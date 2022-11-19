using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ICollectionOperator : IFunctionalityMarker
	{
		public bool EqualCounts<T>(
			ICollection<T> a,
			ICollection<T> b)
		{
			var countsAreEqual = a.Count == b.Count;
			return countsAreEqual;
		}

		public bool IsEmpty<T>(ICollection<T> values)
		{
			var output = values.Count == 0;
			return output;
		}

		public void VerifyEqualCounts<T>(
			ICollection<T> a,
			ICollection<T> b)
		{
			var countsAreEqual = this.EqualCounts(a, b);
			if (!countsAreEqual)
			{
				throw ExceptionOperator.Instance.GetCollectionCountsUnequalException(a, b);
			}
		}
	}
}