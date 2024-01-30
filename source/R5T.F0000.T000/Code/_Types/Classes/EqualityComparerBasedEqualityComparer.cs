using System;

using R5T.T0142;


namespace R5T.F0000.T000
{
    /// <summary>
    /// <para>See new work in R5T.T0221.</para>
    /// 
    /// A <see cref="System.Collections.Generic.IEqualityComparer{T}"/>-based equality comparer.
    /// </summary>
    [UtilityTypeMarker]
    public class EqualityComparerBasedEqualityComparer<T> : IEqualityComparer<T>
    {
        #region Static

        public static EqualityComparerBasedEqualityComparer<T> Default => new EqualityComparerBasedEqualityComparer<T>(
            System.Collections.Generic.EqualityComparer<T>.Default);


        public static EqualityComparerBasedEqualityComparer<T> From(
            System.Collections.Generic.IEqualityComparer<T> equalityComparer)
        {
            var output = new EqualityComparerBasedEqualityComparer<T>(equalityComparer);
            return output;
        }

        #endregion


        private System.Collections.Generic.IEqualityComparer<T> EqualityComparer { get; }


        public EqualityComparerBasedEqualityComparer(
            System.Collections.Generic.IEqualityComparer<T> equalityComparer)
        {
            this.EqualityComparer = equalityComparer;
        }

        public bool Equals(T x, T y)
        {
            var areEqual = this.EqualityComparer.Equals(x, y);
            return areEqual;
        }
    }
}
