using System;
using System.Collections.Generic;

using R5T.T0132;
using R5T.T0221;


namespace R5T.F0000
{
    [FunctionalityMarker]
	public partial interface IListOperator : IFunctionalityMarker,
		L0066.IListOperator
	{
        public WasFound<T> HasNth<T>(IList<T> list, int n)
		{
			var hasNth = this.Has_Nth(
				list,
				n,
				out var nthOrDefault);

			var output = WasFound.From(
				hasNth,
				nthOrDefault);

			return output;
		}

		public WasFound<T> HasSecond<T>(IList<T> list)
		{
			var output = this.HasNth(list, 2);
			return output;
		}
	}
}