using System;
using System.Collections.Generic;
using System.Diagnostics;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IExceptionOperator : IFunctionalityMarker
	{
		private static Internal.IExceptionOperator Internal => F0000.Internal.ExceptionOperator.Instance;


		/// <summary>
		/// <inheritdoc cref="Documentation.ArrayLengthsNotActuallyChecked" path="/summary"/>
		/// Just gets the exception assuming that is the case.
		/// </summary>
		public Exception GetArrayLengthsUnequalException(Array a, Array b)
        {
			var message = MessageOperator.Instance.GetUnequalArrayLengths(a, b);

			var output = new Exception(message);
			return output;
        }

		public Exception GetErrorDataReceivedException(DataReceivedEventArgs eventArgs)
        {
			var exception = new Exception(Instances.ExceptionMessageOperator.MessageIfMessageIsNull(
				eventArgs.Data,
				Instances.Messages.EventDataReceivedWasNull));

			return exception;
		}

		/// <summary>
		/// <inheritdoc cref="Documentation.CollectionCountsNotActuallyChecked" path="/summary"/>
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
		/// <inheritdoc cref="Documentation.DictionaryCountsNotActuallyChecked" path="/summary"/>
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

		/// <summary>
		/// <inheritdoc cref="Documentation.ListCountsNotActuallyChecked" path="/summary"/>
		/// Just gets the exception assuming that is the case.
		/// </summary>
		public Exception GetListCountsUnequalException<T>(
			IList<T> a,
			IList<T> b)
		{
			var message = MessageOperator.Instance.GetUnequalListCounts(a, b);

			var output = new Exception(message);
			return output;
		}

		public UnhandledValueException<TValue> Get_UnhandledValueException<TValue>(TValue value)
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


namespace R5T.F0000.Internal
{
	[FunctionalityMarker]
	public partial interface IExceptionOperator : IFunctionalityMarker
	{
        public string Get_UnhandledValueExceptionMessage<TValue>(TValue value)
        {
            var typeName = Instances.TypeOperator.GetTypeNameOf(value);

            var message = $"Unhandled value:\nt'{value}': value\nt{typeName}: type name";
            return message;
        } 
    }
}