using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public interface IStringOperator : IFunctionalityMarker
	{
        public bool ContainsAny(
            string @string,
            string[] searchStrings)
        {
            var index = this.IndexOfAny(@string, searchStrings);

            var wasFound = this.WasFound(index);
            return wasFound;
        }

        public bool ContainsAny(
            string @string,
            char[] searchCharacters)
        {
            var index = this.IndexOfAny(@string, searchCharacters);

            var wasFound = this.WasFound(index);
            return wasFound;
        }

        public string Enquote(string @string)
        {
            var output = $"\"{@string}\"";
            return output;
        }

        public string EnsureEnquoted(string @string)
        {
            var firstChar = @string.First();
            var lastChar = @string.Last();

            var firstQuoteToken = firstChar == Instances.Characters.Quote
                ? Instances.Strings.Empty
                : Instances.Strings.Quote
                ;

            var lastQuoteToken = lastChar == Instances.Characters.Quote
                ? Instances.Strings.Empty
                : Instances.Strings.Quote
                ;

            var output = $"{firstQuoteToken}{@string}{lastQuoteToken}";
            return output;
        }

        /// <summary>
        /// The default <see cref="System.String.GetHashCode()"/> is non-deterministic.
        /// This method just calls that method.
        /// </summary>
        public int GetHashCode_NonDeterministic(string @string)
        {
            var output = @string.GetHashCode();
            return output;
        }

        /// <summary>
        /// The default <see cref="System.String.GetHashCode()"/> is non-deterministic.
        /// This method provides a deterministic implementation.
        /// </summary>
        /// <remarks>
        /// Source: https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/#a-deterministic-gethashcode-implementation
        /// </remarks>
        public int GetHashCode_Deterministic(string @string)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < @string.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ @string[i];

                    if (i == @string.Length - 1)
                        break;

                    hash2 = ((hash2 << 5) + hash2) ^ @string[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        public char GetLastCharacter(string @string)
        {
			var output = @string[^1];
			return output;
        }

        /// <summary>
        /// A quality-of-life overload for <see cref="IsNotNullAndNotEmpty(string)"/>.
        /// </summary>
        public bool HasValue(string @string)
        {
            var output = this.IsNotNullAndNotEmpty(@string);
            return output;
        }

        public int IndexOfAny(
            string @string,
            string[] searchStrings)
        {
            foreach (var searchString in searchStrings)
            {
                var index = @string.IndexOf(searchString);

                var wasFound = this.WasFound(index);
                if (wasFound)
                {
                    return index;
                }
            }

            return Instances.String.IndexOfNotFound;
        }

        public int IndexOfAny(
            string @string,
            char[] searchCharacters)
        {
            var index = @string.IndexOfAny(searchCharacters);

            var wasFound = this.WasFound(index);
            if (wasFound)
            {
                return index;
            }

            return Instances.String.IndexOfNotFound;
        }

        public bool IsNotNullAndNotEmpty(string @string)
        {
            var isNullOrEmpty = this.IsNullOrEmpty(@string);

            var isNotNullAndNotEmpty = !isNullOrEmpty;
            return isNotNullAndNotEmpty;
        }

        public bool IsNullOrEmpty(string @string)
        {
            var output = System.String.IsNullOrEmpty(@string);
            return output;
        }

        public string Join(char separator, IEnumerable<string> strings)
        {
            var output = System.String.Join(separator, strings);
            return output;
        }

        public string Join(char separator, params string[] strings)
        {
            var output = this.Join(separator, strings.AsEnumerable());
            return output;
        }

        public string Join(string separator, IEnumerable<string> strings)
        {
            var output = System.String.Join(separator, strings);
            return output;
        }

        public string Join(string separator, params string[] strings)
        {
            var output = this.Join(separator, strings.AsEnumerable());
            return output;
        }

        public bool NotFound(int index)
        {
            var output = index == Instances.String.IndexOfNotFound;
            return output;
        }

        public string[] Split(char separator, string @string, StringSplitOptions options = StringSplitOptions.None)
        {
            var output = @string.Split(separator, options);
            return output;
        }

        public bool StartsWith(string @string, string start)
        {
            var isNull = @string is null;
            var startIsNull = start is null;

            if(isNull)
            {
                // If the string is null, then it all depends on the start. If the start is null, then true, else false.
                return startIsNull;
            }
            // Now we know the string is not null.

            if(startIsNull)
            {
                // If the string is not null, but the start is null, then false.
                return false;
            }
            // Now we know the start is not null.

            var isTooShort = @string.Length < start.Length;
            if(isTooShort)
            {
                return false;
            }
            // Now we know it is at least of the right length.

            // Use a span to avoid creating an extra string on the heap.
            var output = MemoryExtensions.Equals(
                @string.AsSpan(0, start.Length),
                start,
                StringComparison.Ordinal);

            return output;
        }

        public string Trim(string @string)
        {
			var output = @string.Trim();
			return output;
        }

		public bool WasFound(int index)
        {
			var output = index != Instances.String.IndexOfNotFound;
			return output;
        }
	}
}