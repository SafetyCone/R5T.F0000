using System;
using System.Collections.Generic;
using System.Linq;

using R5T.N0000;
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

		public bool EqualCounts<T>(
			IList<T> a,
			IList<T> b)
		{
			var lengthsAreEqual = a.Count == b.Count;
			return lengthsAreEqual;
		}

		public bool IsEmpty<T>(IList<T> values)
		{
			var output = values.Count == 0;
			return output;
		}

		public T Get_First<T>(IList<T> list)
		{
			var output = list[0];
			return output;
		}

        public T Get_Second<T>(IList<T> list)
        {
            var output = list[1];
            return output;
        }

        public WasFound<T> HasNth<T>(IList<T> list, int n)
		{
			var count = list.Count;

			if(n > count)
            {
				return WasFound.NotFound<T>();
            }

			var nth = list[n - 1];

			return WasFound.Found(nth);
		}

		public T Nth<T>(IList<T> list, int n)
		{
			var wasFound = this.HasNth(list, n);
			if (!wasFound)
			{
				throw new InvalidOperationException($"List did not have an Nth (N = {n}) element.");
			}

			return wasFound.Result;
		}

		public T NthOrDefault<T>(IList<T> list, int n)
		{
			var wasFound = this.HasNth(list, n);

			var output = wasFound.ResultOrDefaultIfNotFound();
			return output;
		}

		public WasFound<T> HasSecond<T>(IList<T> list)
		{
			var output = this.HasNth(list, 2);
			return output;
		}

		public T Second<T>(IList<T> list)
		{
			var output = this.Nth(list, 2);
			return output;
		}

		public T SecondOrDefault<T>(IList<T> list)
		{
			var output = this.NthOrDefault(list, 2);
			return output;
		}

		public void VerifyEqualCounts<T>(
			IList<T> a,
			IList<T> b)
		{
			var lengthsAreEqual = this.EqualCounts(a, b);
			if (!lengthsAreEqual)
			{
				throw ExceptionOperator.Instance.GetListCountsUnequalException(a, b);
			}
		}
	}
}