using System;
using System.Collections.Generic;

using R5T.T0132;
using R5T.T0143;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IExceptionOperator : IFunctionalityMarker,
		L0053.IExceptionOperator
	{
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0053.IExceptionOperator _L0053 => L0053.ExceptionOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles

        //private static Internal.IExceptionOperator Internal => F0000.Internal.ExceptionOperator.Instance;


        /// <summary>
        /// <inheritdoc cref="L0066.Documentation.ArrayLengthsNotActuallyChecked" path="/summary"/>
        /// Just gets the exception assuming that is the case.
        /// </summary>
        public Exception GetArrayLengthsUnequalException(Array a, Array b)
        {
			var message = MessageOperator.Instance.GetUnequalArrayLengths(a, b);

			var output = new Exception(message);
			return output;
        }

        /// <summary>
        /// <inheritdoc cref="L0066.Documentation.CollectionCountsNotActuallyChecked" path="/summary"/>
        /// Just gets the exception assuming that is the case.
        /// </summary>
        public Exception GetCollectionCountsUnequalException<T>(
			ICollection<T> a,
			ICollection<T> b)
		{
			var message = MessageOperator.Instance.GetUnequalCollectionCounts(a, b);

			var output = new Exception(message);
			return output;
		}

        /// <summary>
        /// <inheritdoc cref="L0066.Documentation.DictionaryCountsNotActuallyChecked" path="/summary"/>
        /// Just gets the exception assuming that is the case.
        /// </summary>
        public Exception GetDictionaryCountsUnequalException<TKey, TValue>(
			IDictionary<TKey, TValue> a,
			IDictionary<TKey, TValue> b)
		{
			var message = MessageOperator.Instance.GetUnequalDictionaryCounts(a, b);

			var output = new Exception(message);
			return output;
		}

		new public UnhandledValueException<TValue> Get_UnhandledValueException<TValue>(TValue value)
		{
			return new UnhandledValueException<TValue>(value);
		}

		public Exception Get_UnhandledValueException(
			string value,
			string preface)
		{
			var message = $"{preface}: {value}";

			return new Exception(message);
		}

		public ArgumentException New_ArgumentException(string message)
		{
			var exception = new ArgumentException(message);
			return exception;
		}
	}
}