using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IArrayOperator : IFunctionalityMarker,
		L0053.IArrayOperator
	{
		public bool EqualLengths(Array a, Array b)
        {
			var lengthsAreEqual = a.Length == b.Length;
			return lengthsAreEqual;
		}

		public void VerifyEqualLengths(Array a, Array b)
        {
			var lengthsAreEqual = this.EqualLengths(a, b);
			if(!lengthsAreEqual)
            {
				throw ExceptionOperator.Instance.GetArrayLengthsUnequalException(a, b);
            }
        }
	}
}