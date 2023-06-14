using System;
using System.Collections.Generic;

using R5T.T0142;


namespace R5T.F0000
{
    [UtilityTypeMarker]
    public class MethodBasedComparer<T> : IComparer<T>
    {
        public Func<T, T, int> ComparerMethod { get; }


        public MethodBasedComparer(Func<T, T, int> comparerMethod)
        {
            this.ComparerMethod = comparerMethod;
        }

        public int Compare(T x, T y)
        {
            var output = this.ComparerMethod(x, y);
            return output;
        }
    }
}
