using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IHashSetOperator : IFunctionalityMarker
	{
        /// <summary>
        /// Chooses <see cref="AddRangeKeepLast{T}(HashSet{T}, IEnumerable{T})"/> as the default behavior (which it is for <see cref="HashSet{T}"/>).
        /// </summary>
        public HashSet<T> AddRange<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            return this.AddRangeKeepLast(hashSet, items);
        }

        /// <summary>
        /// If the hash set already contains the item, replace it with any later items.
        /// This is the default behavior for <see cref="HashSet{T}"/>.
        /// </summary>
        public HashSet<T> AddRangeKeepLast<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                hashSet.Add(item);
            }

            return hashSet;
        }

        /// <summary>
        /// If the hash set already contains the item, do not replace it with any later items.
        /// </summary>
        public HashSet<T> AddRangeKeepFirst<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var containsItem = hashSet.Contains(item);

                // Only add the item if the hash set does not already have the item.
                if (!containsItem)
                {
                    hashSet.Add(item);
                }
            }

            return hashSet;
        }

        public void AddRangeThrowIfDuplicate<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var alreadyPresent = hashSet.Contains(item);
                if (alreadyPresent)
                {
                    throw this.GetValueAlreadyExistsException(item);
                }
            }
        }

        public Exception GetValueAlreadyExistsException<T>(T value)
        {
            var output = new Exception($"Value already exists. Attempted to add duplicate value: {value}");
            return output;
        }
    }
}