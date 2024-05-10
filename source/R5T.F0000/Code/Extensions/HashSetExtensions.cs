using System;
using System.Collections.Generic;

using R5T.F0000;


public static class HashSetExtensions
{
    /// <summary>
    /// Chooses <see cref="AddRangeKeepLast{T}(HashSet{T}, IEnumerable{T})"/> as the default behavior (which it is for <see cref="HashSet{T}"/>).
    /// </summary>
    public static HashSet<T> AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> items)
    {
        return HashSetOperator.Instance.Add_Range(hashSet, items);
    }

    /// <summary>
    /// If the hash set already contains the item, replace it with any later items.
    /// This is the default behavior for <see cref="HashSet{T}"/>.
    /// </summary>
    public static HashSet<T> AddRangeKeepLast<T>(this HashSet<T> hashSet, IEnumerable<T> items)
    {
        return HashSetOperator.Instance.Add_Range_KeepLast(hashSet, items);
    }

    /// <summary>
    /// If the hash set already contains the item, do not replace it with any later items.
    /// </summary>
    public static HashSet<T> AddRangeKeepFirst<T>(this HashSet<T> hashSet, IEnumerable<T> items)
    {
        return HashSetOperator.Instance.Add_Range_KeepFirst(hashSet, items);
    }

    public static void AddRangeThrowIfDuplicate<T>(this HashSet<T> hashSet, IEnumerable<T> items)
    {
        HashSetOperator.Instance.Add_Range_ThrowIfDuplicate(hashSet, items);
    }
}
