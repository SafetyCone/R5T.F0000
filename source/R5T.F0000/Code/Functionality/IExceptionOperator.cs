using System;
using System.Diagnostics;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IExceptionOperator : IFunctionalityMarker
	{
		public Exception GetErrorDataReceivedException(DataReceivedEventArgs eventArgs)
        {
			var exception = new Exception(Instances.ExceptionMessageOperator.MessageIfMessageIsNull(
				eventArgs.Data,
				Instances.Messages.EventDataReceivedWasNull));

			return exception;
		}
	}
}