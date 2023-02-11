using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using R5T.T0132;
using R5T.Z0000;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public interface IStringOperator : IFunctionalityMarker
	{
        private static Internal.IStringOperator Internal => F0000.Internal.StringOperator.Instance;


        public string Append(string @string, string appendix)
        {
            var output = @string + appendix;
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="StartsWith(string, string)"/>.
        /// </summary>
        public bool BeginsWith(string @string, string start)
        {
            var output = this.StartsWith(@string, start);
            return output;
        }

        public bool Contains(string @string, string subString)
        {
            var output = @string.Contains(subString);
            return output;
        }

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

        public bool EndsWith(
            string @string,
            string ending)
        {
            var endingLength = ending.Length;

            var stringLength = @string.Length;
            var stringIsLongEnough = stringLength >= endingLength;
            if(!stringIsLongEnough)
            {
                return false;
            }

            var stringEnding = this.GetLastNCharacters(
                @string,
                endingLength);

            var output = stringEnding == ending;
            return output;
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
        /// Returns the string, without the ending.
        /// </summary>
        public string ExceptEnding_Strict(
            string @string,
            string ending)
        {
            var endsWithEnding = this.EndsWith(
                @string,
                ending);

            if (!endsWithEnding)
            {
                throw new ArgumentException($"String '{@string}' did not end with ending '{endsWithEnding}'.", nameof(@string));
            }

            var output = @string[..^ending.Length];
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="ExceptEnding_Strict(string, string)"/>.
        /// </summary>
        public string ExceptEnding(
            string @string,
            string ending)
        {
            var output = this.ExceptEnding_Strict(
                @string,
                ending);

            return output;
        }

        /// <summary>
        /// Robustly returns null or empty for null or empty (respectively).
        /// </summary>
        public string ExceptFirst_Robust(string @string)
        {
            var isNullOrEmpty = this.IsNullOrEmpty(@string);
            if(isNullOrEmpty)
            {
                return @string;
            }

            var output = Internal.ExceptFirst_Unchecked(@string);
            return output;
        }

        /// <summary>
        /// Similar to the String.Length property and the LINQ Count() extension, throws an exception if the string is null or empty.
        /// </summary>
        public string ExceptFirst_Strict(string @string)
        {
            var isNull = this.IsNull(@string);
            if(isNull)
            {
                throw new ArgumentNullException(nameof(@string));
            }

            var isEmpty = this.IsEmpty(@string);
            if(isEmpty)
            {
                throw new ArgumentOutOfRangeException(nameof(@string), "Input string was empty.");
            }

            var output = Internal.ExceptFirst_Unchecked(@string);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="ExceptFirst_Strict(string)"/> as the default.
        /// Check your string lengths!
        /// </summary>
        public string ExceptFirst(string @string)
        {
            var output = this.ExceptFirst_Strict(@string);
            return output;
        }

        public string Format(
            string template,
            params object[] objects)
        {
            var output = System.String.Format(
                template,
                objects);

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

        public string GetLastNCharacters(
            string @string,
            int numberOfCharacters)
        {
            var output = @string[^numberOfCharacters..];
            return output;
        }

        public char GetLastCharacter(string @string)
        {
			var output = @string[^1];
			return output;
        }

        public string GetSpaces(int count)
        {
            var output = new string(
                Instances.Characters.Space,
                count);

            return output;
        }

        public string GetString(StringBuilder stringBuilder, Action<StringBuilder> modifier)
        {
            modifier(stringBuilder);

            var output = stringBuilder.ToString();
            return output;
        }

        public string GetTabAsSpaces(
            int count = Z0000.IValues.DefaultTabSpacesCount_Const)
        {
            var output = this.GetSpaces(count);
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

        /// <summary>
        /// Prefixes a tab to the string.
        /// </summary>
        public string Indent(string @string)
        {
            var output = $"{Strings.Instance.Tab}{@string}";
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

        /// <summary>
        /// Determines if the input is specifically the <see cref="Z0000.IStrings.Empty"/> string.
        /// </summary>
        public bool IsEmpty(string value)
        {
            var isEmpty = value == Instances.Strings.Empty;
            return isEmpty;
        }

        public bool IsNotEmpty(string value)
        {
            var isEmpty = value != Instances.Strings.Empty;
            return isEmpty;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="WasFound(int)"/>.
        /// </summary>
        public bool IsFound(int index)
        {
            var output = this.WasFound(index);
            return output;
        }

        public bool IsNotNullAndNotEmpty(string @string)
        {
            var isNullOrEmpty = this.IsNullOrEmpty(@string);

            var isNotNullAndNotEmpty = !isNullOrEmpty;
            return isNotNullAndNotEmpty;
        }

        public bool IsNull(string @string)
        {
            // Use  instead of:
            // * == null - Equality operator eventually just uses Object.ReferenceEquals().
            // * Object.Equals() - Should be Object.ReferenceEquals() instead.
            // * Object.ReferenceEquals() - IDE0041 message is produced, indicating preference for "is null".
            var output = @string is null;
            return output;
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

        public string Lower(string @string)
        {
            var output = @string.ToLowerInvariant();
            return output;
        }

        public bool NotFound(int index)
        {
            var output = index == Instances.String.IndexOfNotFound;
            return output;
        }

        public IEnumerable<string> OrderAlphabetically(IEnumerable<string> items)
        {
            var output = items.OrderBy(x => x);
            return output;
        }

        public IEnumerable<string> OrderAlphabetically_OnlyIfDebug(IEnumerable<string> items)
        {
            var output = items
#if DEBUG
                .OrderAlphabetically()
#endif
                ;

            return output;
        }

        public string PrefixWith(
            string prefix,
            string @string)
        {
            var output = prefix + @string;
            return output;
        }

        public string Replace(string @string, char newCharacter, char oldCharacter)
        {
            var output = @string.Replace(
                oldCharacter,
                newCharacter);

            return output;
        }

        public string Replace(string @string, char newCharacter, IEnumerable<char> oldCharacters)
        {
            var currentString = @string;

            foreach (var oldCharacter in oldCharacters)
            {
                currentString = this.Replace(currentString, newCharacter, oldCharacter);
            }

            return currentString;
        }

        public string Replace(string @string, char newCharacter, params char[] oldCharacters)
        {
            var output = this.Replace(
                @string,
                newCharacter,
                oldCharacters.AsEnumerable());

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

        /// <summary>
        /// Quality-of-life overload for <see cref="Append(string, string)"/>.
        /// </summary>
        public string Suffix(
            string @string,
            string suffix)
        {
            var output = this.Append(
                @string,
                suffix);

            return output;
        }

        public string Trim(string @string)
        {
			var output = @string.Trim();
			return output;
        }

        public IEnumerable<string> Trim(IEnumerable<string> strings)
        {
            var output = strings
                .Select(@string => this.Trim(@string))
                ;

            return output;
        }

		public bool WasFound(int index)
        {
			var output = index != Instances.String.IndexOfNotFound;
			return output;
        }
	}
}


namespace R5T.F0000.Internal
{
    public partial interface IStringOperator
    {
        public string ExceptFirst_Unchecked(string @string)
        {
            var output = @string[1..];
            return output;
        }
    }
}