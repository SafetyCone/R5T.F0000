using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IListOperator : IFunctionalityMarker
	{
		public void AddRange<T>(
			IList<T> list,
			IEnumerable<T> items)
        {
            foreach (var item in items)
            {
				list.Add(item);
            }
        }

		public void AddRange<T>(
			IList<T> list,
			params T[] items)
		{
			this.AddRange(
				list,
				items.AsEnumerable());
		}
	}
}