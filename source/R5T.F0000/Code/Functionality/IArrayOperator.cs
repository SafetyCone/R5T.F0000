using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IArrayOperator : IFunctionalityMarker
	{
		public bool IsEmpty(Array array)
        {
			var output = array.Length == 0;
			return output;
        }
	}
}