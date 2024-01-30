using System;

using R5T.T0142;


namespace R5T.F0000.T000
{
    /// <summary>
    /// <para>See new work in R5T.T0221.IEqualityComparer.</para>
    /// 
    /// Tests two instances for equality.
    /// Separate from <see cref="System.Collections.Generic.IEqualityComparer{T}"/>, this type does not require defining <see cref="System.Collections.Generic.IEqualityComparer{T}.GetHashCode(T)"/>.
    /// </summary>
    [UtilityTypeMarker]
    public interface IEqualityComparer<in T>
    {
        bool Equals(T x, T y);
    }
}
