using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ISwitchOperator : IFunctionalityMarker
	{
		public ArgumentException GetUnrecognizedSwitchValueException(string value)
        {
			var exception = new ArgumentException($"{value} - Unrecognized switch value.");
			return exception;
        }

		public ArgumentException GetUnrecognizedSwitchValueException(string value, string categoryName)
		{
			var exception = new ArgumentException($"{value}:{categoryName} - Unrecognized switch value for category.");
			return exception;
		}
	}
}