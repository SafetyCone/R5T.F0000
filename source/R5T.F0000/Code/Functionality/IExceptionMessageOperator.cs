using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IExceptionMessageOperator : IFunctionalityMarker
	{
		public string MessageIfMessageIsNull(
			string message,
			string messageIfNull)
        {
			var output = message ?? messageIfNull;
			return output;
        }
	}
}