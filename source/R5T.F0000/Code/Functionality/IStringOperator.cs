using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public interface IStringOperator : IFunctionalityMarker
	{
		public string Trim(string @string)
        {
			var output = @string.Trim();
			return output;
        }
	}
}