using System;
using System.Diagnostics;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IExceptionOperator : IFunctionalityMarker
	{
		public Exception GetUnhandledValueException(string value)
        {
			var message = $"Unhandled value: {value}";

			return new Exception(message);
		}

		public Exception GetUnhandledValueException(
			string value,
			string preface)
		{
			var message = $"{preface}: {value}";

			return new Exception(message);
		}

		public Exception GetErrorDataReceivedException(DataReceivedEventArgs eventArgs)
        {
			var exception = new Exception(Instances.ExceptionMessageOperator.MessageIfMessageIsNull(
				eventArgs.Data,
				Instances.Messages.EventDataReceivedWasNull));

			return exception;
		}

		public ArgumentException New_ArgumentException(string message)
		{
			var exception = new ArgumentException(message);
			return exception;
		}
	}
}