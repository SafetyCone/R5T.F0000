using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IMessageOperator : IFunctionalityMarker
	{
		public string GetUnequalArrayLengths(int lengthA, int lengthB)
        {
			var message = $"Unequal array lengths. Found: {lengthA}, {lengthB}.";
			return message;
		}

		/// <summary>
		/// <inheritdoc cref="Documentation.ArrayLengthsNotActuallyChecked" path="/summary"/>
		/// Just gets the message assuming that is the case.
		/// </summary>
		public string GetUnequalArrayLengths(Array a, Array b)
        {
			var message = this.GetUnequalArrayLengths(
				a.Length,
				b.Length);

			return message;
        }

		public string GetUnequalCollectionCounts(int countA, int countB)
		{
			var message = $"Unequal collection counts. Found: {countA}, {countB}.";
			return message;
		}

		/// <summary>
		/// <inheritdoc cref="Documentation.CollectionCountsNotActuallyChecked" path="/summary"/>
		/// Just gets the message assuming that is the case.
		/// </summary>
		public string GetUnequalCollectionCounts<T>(
			ICollection<T> a,
			ICollection<T> b)
		{
			var message = this.GetUnequalCollectionCounts(
				a.Count,
				b.Count);

			return message;
		}

		public string GetUnequalDictionaryCounts(int countA, int countB)
		{
			var message = $"Unequal dictionary counts. Found: {countA}, {countB}.";
			return message;
		}

		/// <summary>
		/// <inheritdoc cref="Documentation.DictionaryCountsNotActuallyChecked" path="/summary"/>
		/// Just gets the message assuming that is the case.
		/// </summary>
		public string GetUnequalDictionaryCounts<TKey, TValue>(
			IDictionary<TKey, TValue> a,
			IDictionary<TKey, TValue> b)
		{
			var message = this.GetUnequalDictionaryCounts(
				a.Count,
				b.Count);

			return message;
		}

		public string GetUnequalListCounts(int countA, int countB)
		{
			var message = $"Unequal list counts. Found: {countA}, {countB}.";
			return message;
		}

		/// <summary>
		/// <inheritdoc cref="Documentation.CollectionCountsNotActuallyChecked" path="/summary"/>
		/// Just gets the message assuming that is the case.
		/// </summary>
		public string GetUnequalListCounts<T>(
			IList<T> a,
			IList<T> b)
		{
			var message = this.GetUnequalListCounts(
				a.Count,
				b.Count);

			return message;
		}
	}
}