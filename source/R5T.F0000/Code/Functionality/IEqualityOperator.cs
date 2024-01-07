using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IEqualityOperator : IFunctionalityMarker
	{
		/// <summary>
		/// <inheritdoc cref="Array_Elements_StopOnFirst_WithoutVerification{T}(T[], T[], Func{T, T, int, bool})" path="/summary"/>
		/// </summary>
		/// <remarks>
		/// Arrays must be the same length.
		/// </remarks>
		public bool Array_Elements_StopOnFirst<T>(T[] a, T[] b,
			Func<T, T, int, bool> instanceEquals)
		{
			ArrayOperator.Instance.VerifyEqualLengths(a, b);

			var output = this.Array_Elements_StopOnFirst_WithoutVerification(a, b, instanceEquals);
			return output;
		}

		/// <summary>
		/// Tests the equality of the elements in an array, stopping on the first unequal element.
		/// </summary>
		/// <remarks>
		/// No verification is done that the arrays have equal lengths.
		/// </remarks>
		public bool Array_Elements_StopOnFirst_WithoutVerification<T>(T[] a, T[] b,
			Func<T, T, int, bool> instanceEquals)
		{
			// Lengths are assumed to be the same, so ok to use same length.
			for (int i = 0; i < a.Length; i++)
			{
				var aInstance = a[i];
				var bInstance = b[i];

				var instanceEqualsResult = instanceEquals(aInstance, bInstance, i);
				if (!instanceEqualsResult)
				{
					return false;
				}
			}

			return true;
		}

		/// <inheritdoc cref="Array_Elements_ThroughAll_WithoutVerification{T}(T[], T[], Func{T, T, int, bool})" path="/content"/>
		/// <remarks>
		/// Arrays must be the same length.
		/// </remarks>
		public bool Array_Elements_ThroughAll<T>(T[] a, T[] b,
			Func<T, T, int, bool> instanceEquals)
		{
			ArrayOperator.Instance.VerifyEqualLengths(a, b);

			// Assume success.
			var allElementsAreEqual = this.Array_Elements_ThroughAll_WithoutVerification(a, b, instanceEquals);
			return allElementsAreEqual;
		}

		/// <content>
		/// <summary>
		/// Tests the equality of all elements in an array.
		/// The method does not stop on the first unequal element, like <see cref="Array_Elements_StopOnFirst{T}(T[], T[], Func{T, T, int, bool})"/>, but instead continues through the whole array.
		/// </summary>
		/// <returns>False if any elements in the array are unequal, true otherwise.</returns>
		/// </content>
		/// <remarks>
		/// No verification is done that the arrays are the same length.
		/// </remarks>
		public bool Array_Elements_ThroughAll_WithoutVerification<T>(T[] a, T[] b,
			Func<T, T, int, bool> instanceEquals)
		{
			// Assume success.
			var allElementsAreEqual = true;

			// Assume lengths are same, so ok to use same length.
			for (int i = 0; i < a.Length; i++)
			{
				var aInstance = a[i];
				var bInstance = b[i];

				var instanceEqualsResult = instanceEquals(aInstance, bInstance, i);

				// Accumulate any falses.
				allElementsAreEqual &= instanceEqualsResult;
			}

			return allElementsAreEqual;
		}

		/// <summary>
		/// Chooses <see cref="Array_Elements_StopOnFirst{T}(T[], T[], Func{T, T, int, bool})"/> as the default.
		/// </summary>
		public bool Array_Elements<T>(T[] a, T[] b,
			Func<T, T, int, bool> instanceEquals)
		{
			var output = this.Array_Elements_StopOnFirst(
				a,
				b,
				instanceEquals);

			return output;
		}

		public bool Array_Length(Array a, Array b)
        {
			var lengthsAreEqual = ArrayOperator.Instance.EqualLengths(a, b);
			return lengthsAreEqual;
        }

		/// <summary>
		/// Tests the order of elements.
		/// Note: Because instance equality is used to determine if two instances are in the same place, this is the same as <see cref="Array_Elements_StopOnFirst{T}(T[], T[], Func{T, T, int, bool})"/>.
		/// </summary>
		public bool Array_Order<T>(T[] a, T[] b,
			Func<T, T, int, bool> instanceEquals)
        {
			var output = this.Array_Elements_StopOnFirst(a, b, instanceEquals);
			return output;
        }

		/// <summary>
		/// Default equality method for array.
		/// </summary>
		public bool Array<T>(T[] a, T[] b,
			Func<T, T, int, bool> instanceEquals)
        {
			var lengthsAreEqual = this.Array_Length(a, b);
			if(!lengthsAreEqual)
            {
				return false;
            }

			var elementsEqual = this.Array_Elements_StopOnFirst_WithoutVerification(a, b, instanceEquals);
			if(!elementsEqual)
            {
				return false;
            }

			return true;
        }

		public bool Collection_Count<T>(
			ICollection<T> a,
			ICollection<T> b)
		{
			var countsAreEqual = CollectionOperator.Instance.EqualCounts(a, b);
			return countsAreEqual;
		}

		/// <summary>
		/// Tests the equality of the values in the collection, stopping on the first unequal value.
		/// </summary>
		/// <remarks>
		/// No verification is done that the arrays have equal lengths.
		/// </remarks>
		public bool Collection_Values_StopOnFirst_WithoutVerification<T>(
			ICollection<T> a,
			ICollection<T> b,
			Func<T, T, bool> instanceEquals)
		{
			// Counts are assumed to be the same, so ok to treat the collections as an enumerables and not worry about unequal lengths.
			var output = this.Enumerable_Elements_StopOnFirst_OkIfUnequalLengths(
				a,
				b,
				instanceEquals);

			return output;
		}

		/// <summary>
		/// <inheritdoc cref="Collection_Values_StopOnFirst_WithoutVerification{T}(ICollection{T}, ICollection{T}, Func{T, T, bool})" path="/summary"/>
		/// </summary>
		/// <remarks>
		/// Collections must be the same count.
		/// </remarks>
		public bool Collection_Values_StopOnFirst<T>(
			ICollection<T> a,
			ICollection<T> b,
			Func<T, T, bool> instanceEquals)
		{
			CollectionOperator.Instance.VerifyEqualCounts(a, b);

			var output = this.Collection_Values_StopOnFirst_WithoutVerification(a, b, instanceEquals);
			return output;
		}

		/// <content>
		/// <summary>
		/// Tests the equality of all values in a collection.
		/// The method does not stop on the first unequal element, like <see cref="Collection_Values_StopOnFirst{T}(ICollection{T}, ICollection{T}, Func{T, T, bool})"/>, but instead continues through the whole collection.
		/// </summary>
		/// <returns>False if any values in the collection are unequal, true otherwise.</returns>
		/// </content>
		/// <remarks>
		/// No verification is done that the collections have the same counts.
		/// </remarks>
		public bool Collection_Values_ThroughAll_WithoutVerification<T>(
			ICollection<T> a,
			ICollection<T> b,
			Func<T, T, bool> instanceEquals)
		{
			// Counts are assumed to be the same, so ok to treat the collections as an enumerables and not worry about unequal lengths.
			var allElementsAreEqual = this.Enumerable_Elements_ThroughAll_OkIfUnequalLengths(
				a,
				b,
				instanceEquals);

			return allElementsAreEqual;
		}

		/// <inheritdoc cref="Collection_Values_ThroughAll_WithoutVerification{T}(ICollection{T}, ICollection{T}, Func{T, T, bool})" path="/content"/>
		/// <remarks>
		/// Collections must have the same counts.
		/// </remarks>
		public bool Collection_Values_ThroughAll<T>(
			ICollection<T> a,
			ICollection<T> b,
			Func<T, T, bool> instanceEquals)
		{
			CollectionOperator.Instance.VerifyEqualCounts(a, b);

			// Assume success.
			var allElementsAreEqual = this.Collection_Values_ThroughAll_WithoutVerification(a, b, instanceEquals);
			return allElementsAreEqual;
		}

		/// <summary>
		/// Chooses <see cref="Collection_Values_StopOnFirst{T}(ICollection{T}, ICollection{T}, Func{T, T, bool})"/> as the default.
		/// </summary>
		public bool Collection_Values<T>(T[] a, T[] b,
			Func<T, T, bool> instanceEquals)
		{
			var output = this.Collection_Values_StopOnFirst(
				a,
				b,
				instanceEquals);

			return output;
		}

		/// <summary>
		/// Default equality method for collections.
		/// </summary>
		public bool Collection<T>(
			ICollection<T> a,
			ICollection<T> b,
			Func<T, T, bool> instanceEquals)
		{
			var countsAreEqual = this.Collection_Count(a, b);
			if (!countsAreEqual)
			{
				return false;
			}

			var valuesEqual = this.Collection_Values_StopOnFirst_WithoutVerification(a, b, instanceEquals);
			if (!valuesEqual)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Tests the elements of two dictionaries for equality.
		/// </summary>
		public bool Dictionary<TKey, TValue>(
			IDictionary<TKey, TValue> a,
			IDictionary<TKey, TValue> b,
			IComparer<TKey> keyOrder,
			Func<TKey, TKey, bool> keyEquals,
			Func<TValue, TValue, bool> valueEquals)
		{
			// Are the counts the same?
			var countsAreEqual = this.Dictionary_Count(a, b);

			if (!countsAreEqual)
			{
				return false;
			}

			// After ordering the keys, are the keys in the same order?
			var orderedKeysA = a.Keys.OrderBy(
				x => x,
				keyOrder);

			var orderedKeysB = b.Keys.OrderBy(
				x => x,
				keyOrder);

			// The counts are the same, and the order of the keys is the same as testing each instance of the keys.
			var keysInOrderAreEqual = this.Enumerable_Elements_StopOnFirst_OkIfUnequalLengths(
				orderedKeysA,
				orderedKeysB,
				keyEquals);

			if (!keysInOrderAreEqual)
			{
				return false;
			}

			// Are the values for each key the same?
			// Keys are the same, so just use the keys for a.
			foreach (var key in a.Keys)
			{
				var valueA = a[key];
				var valueB = b[key];

				var valueIsEqual = valueEquals(valueA, valueB);
				if (!valueIsEqual)
				{
					return false;
				}
			}

			// Success.
			return true;
		}

		public bool Dictionary_Count<TKey, TValue>(
			IDictionary<TKey, TValue> a,
			IDictionary<TKey, TValue> b)
		{
			var countsAreEqual = DictionaryOperator.Instance.EqualCounts(a, b);
			return countsAreEqual;
		}

		/// <summary>
		/// <inheritdoc cref="Enumerable_Elements_StopOnFirst{T}(IEnumerable{T}, IEnumerable{T}, Func{T, T, bool})" path="/summary"/>
		/// Uses the <inheritdoc cref="Y0000.Glossary.ForEnumerable.Comparison_OkIfUnequalLength" path="/name"/> behavior.
		/// </summary>
		public bool Enumerable_Elements_StopOnFirst_OkIfUnequalLengths<T>(
			IEnumerable<T> a,
			IEnumerable<T> b,
			Func<T, T, bool> instanceEquals)
		{
			var enumerateElementsAreEqual = EnumerableOperator.Instance.Zip_OkIfUnequalLengths(
				a,
				b,
				instanceEquals);

			foreach (var elementsAreEqual in enumerateElementsAreEqual)
			{
				if (!elementsAreEqual)
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// <inheritdoc cref="Enumerable_Elements_StopOnFirst{T}(IEnumerable{T}, IEnumerable{T}, Func{T, T, bool})" path="/summary"/>
		/// Uses the <inheritdoc cref="Y0000.Glossary.ForEnumerable.Comparison_ThrowIfUnequalLength" path="/name"/> behavior.
		/// </summary>
		public bool Enumerable_Elements_StopOnFirst_ThrowIfUnequalLengths<T>(
			IEnumerable<T> a,
			IEnumerable<T> b,
			Func<T, T, bool> instanceEquals)
		{
			var enumerateElementsAreEqual = EnumerableOperator.Instance.Zip_ThrowIfUnequalLengths(
				a,
				b,
				instanceEquals);

			foreach (var elementsAreEqual in enumerateElementsAreEqual)
			{
				if (!elementsAreEqual)
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Tests the elements of two <see cref="IEnumerable{T}"/>s for equality.
		/// Uses the <inheritdoc cref="Y0000.Glossary.ForEnumerable.Comparison_StopOnFirst" path="/name"/> behavior.
		/// </summary>
		/// <remarks>
		/// Chooses the <see cref="Enumerable_Elements_StopOnFirst_OkIfUnequalLengths{T}(IEnumerable{T}, IEnumerable{T}, Func{T, T, bool})"/> the default.
		/// </remarks>
		public bool Enumerable_Elements_StopOnFirst<T>(
			IEnumerable<T> a,
			IEnumerable<T> b,
			Func<T, T, bool> instanceEquals)
		{
			return this.Enumerable_Elements_StopOnFirst_OkIfUnequalLengths(a, b, instanceEquals);
		}

		/// <summary>
		/// <inheritdoc cref="Enumerable_Elements_StopOnFirst{T}(IEnumerable{T}, IEnumerable{T}, Func{T, T, int, bool})" path="/summary"/>
		/// Uses the <inheritdoc cref="Y0000.Glossary.ForEnumerable.Comparison_OkIfUnequalLength" path="/name"/> behavior.
		/// </summary>
		public bool Enumerable_Elements_StopOnFirst_OkIfUnequalLengths<T>(
			IEnumerable<T> a,
			IEnumerable<T> b,
			Func<T, T, int, bool> instanceEquals)
		{
			var enumerateElementsAreEqual = EnumerableOperator.Instance.Zip_OkIfUnequalLengths(
				a,
				b,
				instanceEquals);

			foreach (var elementsAreEqual in enumerateElementsAreEqual)
			{
				if (!elementsAreEqual)
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Tests the elements of two <see cref="IEnumerable{T}"/>s for equality.
		/// Uses the <inheritdoc cref="Y0000.Glossary.ForEnumerable.Comparison_StopOnFirst" path="/name"/> behavior.
		/// </summary>
		/// <remarks>
		/// Chooses the <see cref="Enumerable_Elements_StopOnFirst_OkIfUnequalLengths{T}(IEnumerable{T}, IEnumerable{T}, Func{T, T, int, bool})"/> the default.
		/// </remarks>
		public bool Enumerable_Elements_StopOnFirst<T>(
			IEnumerable<T> a,
			IEnumerable<T> b,
			Func<T, T, int, bool> instanceEquals)
		{
			return this.Enumerable_Elements_StopOnFirst_OkIfUnequalLengths(a, b, instanceEquals);
		}

		/// <summary>
		/// <inheritdoc cref="Enumerable_Elements_ThroughAll{T}(IEnumerable{T}, IEnumerable{T}, Func{T, T, bool})" path="/summary"/>
		/// Uses the <inheritdoc cref="Y0000.Glossary.ForEnumerable.Comparison_OkIfUnequalLength" path="/name"/> behavior.
		/// </summary>
		public bool Enumerable_Elements_ThroughAll_OkIfUnequalLengths<T>(
			IEnumerable<T> a,
			IEnumerable<T> b,
			Func<T, T, bool> instanceEquals)
		{
			var enumerateElementsAreEqual = EnumerableOperator.Instance.Zip_OkIfUnequalLengths(
				a,
				b,
				instanceEquals);

			// Accumulate outputs.
			var output = true;

			foreach (var elementsAreEqual in enumerateElementsAreEqual)
			{
				output &= elementsAreEqual;
			}

			return output;
		}

		/// <summary>
		/// <inheritdoc cref="Enumerable_Elements_ThroughAll{T}(IEnumerable{T}, IEnumerable{T}, Func{T, T, bool})" path="/summary"/>
		/// Uses the <inheritdoc cref="Y0000.Glossary.ForEnumerable.Comparison_OkIfUnequalLength" path="/name"/> behavior.
		/// </summary>
		public bool Enumerable_Elements_ThroughAll_OkIfUnequalLengths<T>(
			IEnumerable<T> a,
			IEnumerable<T> b,
			Func<T, T, int, bool> instanceEquals)
		{
			var enumerateElementsAreEqual = EnumerableOperator.Instance.Zip_OkIfUnequalLengths(
				a,
				b,
				instanceEquals);

			// Accumulate outputs.
			var output = true;

			foreach (var elementsAreEqual in enumerateElementsAreEqual)
			{
				output &= elementsAreEqual;
			}

			return output;
		}

		/// <summary>
		/// <inheritdoc cref="Enumerable_Elements_ThroughAll{T}(IEnumerable{T}, IEnumerable{T}, Func{T, T, bool})" path="/summary"/>
		/// Uses the <inheritdoc cref="Y0000.Glossary.ForEnumerable.Comparison_ThrowIfUnequalLength" path="/name"/> behavior.
		/// </summary>
		public bool Enumerable_Elements_ThroughAll_ThrowIfUnequalLengths<T>(
			IEnumerable<T> a,
			IEnumerable<T> b,
			Func<T, T, bool> instanceEquals)
		{
			var enumerateElementsAreEqual = EnumerableOperator.Instance.Zip_ThrowIfUnequalLengths(
				a,
				b,
				instanceEquals);

			// Accumulate outputs.
			var output = true;

			foreach (var elementsAreEqual in enumerateElementsAreEqual)
			{
				output &= elementsAreEqual;
			}

			return output;
		}

		/// <summary>
		/// Tests the elements of two <see cref="IEnumerable{T}"/>s for equality.
		/// Uses the <inheritdoc cref="Y0000.Glossary.ForEnumerable.Comparison_ThroughAll" path="/name"/> behavior.
		/// </summary>
		/// <remarks>
		/// Chooses the <see cref="Enumerable_Elements_ThroughAll_OkIfUnequalLengths{T}(IEnumerable{T}, IEnumerable{T}, Func{T, T, bool})"/> the default.
		/// </remarks>
		public bool Enumerable_Elements_ThroughAll<T>(
			IEnumerable<T> a,
			IEnumerable<T> b,
			Func<T, T, bool> instanceEquals)
		{
			return this.Enumerable_Elements_ThroughAll_OkIfUnequalLengths(a, b, instanceEquals);
		}

		/// <summary>
		/// Chooses <see cref="Enumerable_Elements_StopOnFirst{T}(IEnumerable{T}, IEnumerable{T}, Func{T, T, bool})"/> as the default.
		/// </summary>
		public bool Enumerable_Elements<T>(
			IEnumerable<T> a,
			IEnumerable<T> b,
			Func<T, T, bool> instanceEquals)
		{
			return this.Enumerable_Elements_StopOnFirst(a, b, instanceEquals);
		}

		public bool List_Count<T>(
			IList<T> a,
			IList<T> b)
		{
			var countsAreEqual = ListOperator.Instance.Equal_Counts(a, b);
			return countsAreEqual;
		}

		/// <summary>
		/// Tests the equality of the values in the collection, stopping on the first unequal value.
		/// </summary>
		/// <remarks>
		/// No verification is done that the arrays have equal lengths.
		/// </remarks>
		public bool List_Values_StopOnFirst_WithoutVerification<T>(
			IList<T> a,
			IList<T> b,
			Func<T, T, int, bool> instanceEquals)
		{
			// Counts are assumed to be the same, so ok to treat the collections as an enumerables and not worry about unequal lengths.
			var output = this.Enumerable_Elements_StopOnFirst_OkIfUnequalLengths(
				a,
				b,
				instanceEquals);

			return output;
		}

		/// <summary>
		/// <inheritdoc cref="List_Values_StopOnFirst_WithoutVerification{T}(IList{T}, IList{T}, Func{T, T, int, bool})" path="/summary"/>
		/// </summary>
		/// <remarks>
		/// Lists must be the same count.
		/// </remarks>
		public bool List_Values_StopOnFirst<T>(
			IList<T> a,
			IList<T> b,
			Func<T, T, int, bool> instanceEquals)
		{
			ListOperator.Instance.Verify_EqualCounts(a, b);

			var output = this.List_Values_StopOnFirst_WithoutVerification(a, b, instanceEquals);
			return output;
		}

		/// <content>
		/// <summary>
		/// Tests the equality of all values in a collection.
		/// The method does not stop on the first unequal element, like <see cref="List_Values_StopOnFirst{T}(IList{T}, IList{T}, Func{T, T, int, bool})"/>, but instead continues through the whole collection.
		/// </summary>
		/// <returns>False if any values in the collection are unequal, true otherwise.</returns>
		/// </content>
		/// <remarks>
		/// No verification is done that the collections have the same counts.
		/// </remarks>
		public bool List_Values_ThroughAll_WithoutVerification<T>(
			IList<T> a,
			IList<T> b,
			Func<T, T, int, bool> instanceEquals)
		{
			// Counts are assumed to be the same, so ok to treat the collections as an enumerables and not worry about unequal lengths.
			var allElementsAreEqual = this.Enumerable_Elements_ThroughAll_OkIfUnequalLengths(
				a,
				b,
				instanceEquals);

			return allElementsAreEqual;
		}

		/// <inheritdoc cref="List_Values_ThroughAll_WithoutVerification{T}(IList{T}, IList{T}, Func{T, T, int, bool})" path="/content"/>
		/// <remarks>
		/// Lists must have the same counts.
		/// </remarks>
		public bool List_Values_ThroughAll<T>(T[] a, T[] b,
			Func<T, T, int, bool> instanceEquals)
		{
			ArrayOperator.Instance.VerifyEqualLengths(a, b);

			// Assume success.
			var allElementsAreEqual = this.List_Values_ThroughAll_WithoutVerification(a, b, instanceEquals);
			return allElementsAreEqual;
		}

		/// <summary>
		/// Chooses <see cref="List_Values_StopOnFirst{T}(IList{T}, IList{T}, Func{T, T, int, bool})"/> as the default.
		/// </summary>
		public bool Collection_Values<T>(
			IList<T> a,
			IList<T> b,
			Func<T, T, int, bool> instanceEquals)
		{
			var output = this.List_Values_StopOnFirst(
				a,
				b,
				instanceEquals);

			return output;
		}

		/// <summary>
		/// Default equality method for lists.
		/// </summary>
		public bool List<T>(
			IList<T> a,
			IList<T> b,
			Func<T, T, int, bool> instanceEquals)
		{
			var countsAreEqual = this.List_Count(a, b);
			if (!countsAreEqual)
			{
				return false;
			}

			var valuesEqual = this.List_Values_StopOnFirst_WithoutVerification(a, b, instanceEquals);
			if (!valuesEqual)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Tests the order of values.
		/// Note: Because instance equality is used to determine if two values are in the same place, this is the same as <see cref="List_Values_StopOnFirst{T}(IList{T}, IList{T}, Func{T, T, int, bool})"/>.
		/// </summary>
		public bool List_Order<T>(T[] a, T[] b,
			Func<T, T, int, bool> instanceEquals)
		{
			var output = this.List_Values_StopOnFirst(a, b, instanceEquals);
			return output;
		}
	}
}