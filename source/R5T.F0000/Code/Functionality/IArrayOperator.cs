using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IArrayOperator : IFunctionalityMarker
	{
		public T[] New_Empty<T>()
		{
			return new T[0];
		}

		public T[] From<T>(T value)
		{
			var output = new[]
			{
				value,
			};

			return output;
		}

		public bool EqualLengths(Array a, Array b)
        {
			var lengthsAreEqual = a.Length == b.Length;
			return lengthsAreEqual;
		}

		public bool IsEmpty(Array array)
        {
			var output = array.Length == 0;
			return output;
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