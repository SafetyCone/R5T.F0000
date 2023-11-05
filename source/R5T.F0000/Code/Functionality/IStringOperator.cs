using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using R5T.N0000;
using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public interface IStringOperator : IFunctionalityMarker,
        L0053.IStringOperator
	{
        private static Internal.IStringOperator Internal => F0000.Internal.StringOperator.Instance;


        public string Convert_StructuredString_ToFormatString(string structuredString)
        {
            var count = 0;

            var formatString = Regex.Replace(
                structuredString,
                RegularExpressionPatterns.Instance.AnythingInsideBraces,
                match =>
                {
                    return $"{{{count++}}}";
                });

            return formatString;
        }

        public string Enquote(string @string)
        {
            var output = $"\"{@string}\"";
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

        public string FormatStructuredString(
            string structuredString,
            params object[] arguments)
        {
            var stringFormatMessage = Instances.StringOperator.Convert_StructuredString_ToFormatString(structuredString);

            var output = System.String.Format(stringFormatMessage, arguments);
            return output;
        }

        public string FromIndex_Exclusive(
            int index,
            string @string)
        {
            var output = @string[(index + 1)..];
            return output;
        }

        public string FromIndex_Inclusive(
            int index,
            string @string)
        {
            var output = @string[index..];
            return output;
        }

        /// <summary>
        /// Chooses <see cref="FromIndex_Inclusive(int, string)"/> as the default (since the matches the range-operator behavior).
        /// </summary>
        public string FromIndex(
            int index,
            string @string)
        {
            var output = this.FromIndex_Inclusive(index, @string);
            return output;
        }

        public int Get_CountOf(
            char character,
            string @string)
        {
            var count = 0;

            for (int iCharacter = 0; iCharacter < @string.Length; iCharacter++)
            {
                var currentCharacter = @string[iCharacter];

                if(currentCharacter == character)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Gets the first character of the string.
        /// </summary>
        /// <remarks>
        /// This must duplicate <see cref="IListOperator.Get_First{T}(IList{T})"/> because string does not actually implement <see cref="IList{T}"/> of <see cref="char"/>
        /// (because it does not implement <see cref="Array"/> of <see cref="char"/>).
        /// </remarks>
        public char Get_First(string @string)
        {
            var output = @string[0];
            return output;
        }

        /// <summary>
        /// Gets the first character of the string.
        /// </summary>
        /// <remarks>
        /// This must duplicate <see cref="IListOperator.Get_Second{T}(IList{T})"/> because string does not actually implement <see cref="IList{T}"/> of <see cref="char"/>
        /// (because it does not implement <see cref="Array"/> of <see cref="char"/>).
        /// </remarks>
        public char Get_Second(string @string)
        {
            var output = @string[1];
            return output;
        }

        public string Get_FirstNCharacters(string @string, int numberOfCharacters)
        {
            var output = @string[..numberOfCharacters];
            return output;
        }

        /// <summary>
        /// Gets the first N characters as a string, given the index of the first character to exclude.
        /// </summary>
        public string Get_FirstNCharacters_ByExclusiveIndex(string @string, int exclusiveIndex)
        {
            var output = @string[..exclusiveIndex];
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

        public new int Get_LastIndexOf(
            char character,
            string @string)
        {
            var lastIndexWasFound = this.LastIndexOf(
                character,
                @string);

            return WasFoundOperator.Instance.ResultOrExceptionIfNotFound(
                lastIndexWasFound,
                () => new ArgumentException($"Character '{character}' not found in string.", nameof(character)));
        }

        public string GetSpaces(int count)
        {
            var output = this.Repeat(
                Instances.Characters.Space,
                count);

            return output;
        }

        public StringComparison Get_StringComparison(bool capitalizationSensitive)
        {
            var stringComparison = capitalizationSensitive
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase
                ;

            return stringComparison;
        }

        public string GetString(StringBuilder stringBuilder, Action<StringBuilder> modifier)
        {
            modifier(stringBuilder);

            var output = stringBuilder.ToString();
            return output;
        }

        /// <summary>
        /// Gets the beginning substring up to, but excluding, the first occurrence of the specified character.
        /// </summary>
        public string Get_Substring_Upto_First(
            string @string,
            char character)
        {
            var firstIndexOfCharacterFound = this.IndexOf(character, @string);
            if(!firstIndexOfCharacterFound)
            {
                throw new Exception($"Character '{character}' not found in string \"{@string}\".");
            }

            var substring = this.Get_Substring_Upto_Exclusive(
                firstIndexOfCharacterFound.Result,
                @string);

            return substring;
        }

        public string Get_Substring_From_First(
            string @string,
            char character)
        {
            var firstIndexOfCharacterFound = this.IndexOf(character, @string);
            if (!firstIndexOfCharacterFound)
            {
                throw new Exception($"Character '{character}' not found in string \"{@string}\".");
            }

            var output = this.Get_Substring_From_Exclusive(
                firstIndexOfCharacterFound.Result,
                @string);

            return output;
        }

        public string Get_Substring_From_Start_To_NextOrEnd(
            string @string,
            char startCharacter,
            char nextCharacter)
        {
            var firstIndexOfStartCharacterFound = this.IndexOf(startCharacter, @string);
            if (!firstIndexOfStartCharacterFound)
            {
                throw new Exception($"Character '{startCharacter}' not found in string \"{@string}\".");
            }

            var substring = this.Get_Substring_From_Exclusive(
                firstIndexOfStartCharacterFound.Result,
                @string);

            var firstIndexOfNextCharacterFound = this.IndexOf(nextCharacter, substring);

            var output = firstIndexOfNextCharacterFound
                ? this.Get_Substring_Upto_Exclusive(
                    firstIndexOfNextCharacterFound.Result,
                    substring)
                : substring
                ;

            return output;
        }

        public string Get_Substring_From_Exclusive(
            string token,
            string @string)
        {
            var indexOfTokenFound = this.IndexOf(token, @string);
            if(!indexOfTokenFound)
            {
                throw new Exception($"Token \"{token}\" not found in string \"{@string}\".");
            }

            var startIndex = indexOfTokenFound + (token.Length - 1);

            var output = this.Get_Substring_From_Exclusive(
                startIndex,
                @string);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="L0053.IStringOperator.Get_Substring_From_Exclusive(int, string)"/> as the default.
        /// </summary>
        public string Get_Substring_Exclusive(
            int startIndex_Exclusive,
            string @string)
        {
            return this.Get_Substring_From_Exclusive(
                startIndex_Exclusive,
                @string);
        }

        public string Get_Substring_Exclusive_Exclusive(
            int startIndex_Exclusive,
            int endIndex_Exclusive,
            string @string)
        {
            var length = endIndex_Exclusive - startIndex_Exclusive;

            var output = @string.Substring(startIndex_Exclusive + 1, length - 1);
            return output;
        }

        public string Get_Substring_Inclusive_Inclusive(
            int startIndex_Inclusive,
            int endIndex_Inclusive,
            string @string)
        {
            var length = endIndex_Inclusive - startIndex_Inclusive;

            var output = @string.Substring(startIndex_Inclusive, length);
            return output;
        }

        /// <summary>
        /// Get a tab as a number of spaces.
        /// <inheritdoc cref="Z0000.IValues.DefaultTabSpacesCount_Const" path="/summary"/>
        /// </summary>
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

        public WasFound<int> IndexOf(
            string token,
            string @string)
        {
            var indexOrNotFound = this.IndexOf_OrNotFound(
                token,
                @string);

            var output = Internal.WasFound(indexOrNotFound);
            return output;
        }

        public WasFound<int> IndexOf(
            char character,
            string @string)
        {
            var indexOrNotFound = this.IndexOf_OrNotFound(
                character,
                @string);

            var output = Internal.WasFound(indexOrNotFound);
            return output;
        }

        public WasFound<int> IndexOf(
            char character,
            string @string,
            int startIndex)
        {
            var indexOrNotFound = this.IndexOf_OrNotFound(
                character,
                @string,
                startIndex);

            var output = Internal.WasFound(indexOrNotFound);
            return output;
        }

        /// <inheritdoc cref="System.String.IndexOf(char)"/>
        public int IndexOf_OrNotFound(
            char character,
            string @string)
        {
            var output = @string.IndexOf(character);
            return output;
        }

        /// <inheritdoc cref="System.String.IndexOf(char)"/>
        public int IndexOf_OrNotFound(
            string token,
            string @string)
        {
            var output = @string.IndexOf(token);
            return output;
        }

        /// <inheritdoc cref="System.String.IndexOf(char, int)"/>
        public int IndexOf_OrNotFound(
            char character,
            string @string,
            int startIndex)
        {
            var output = @string.IndexOf(character, startIndex);
            return output;
        }

        public WasFound<int> IndexOfAny(
            string @string,
            params char[] searchCharacters)
        {
            var indexOrNotFound = this.Get_IndexOfAny_OrNotFound(
                @string,
                searchCharacters);

            var output = Internal.WasFound(indexOrNotFound);
            return output;
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
            var isNullOrEmpty = this.Is_NullOrEmpty(@string);

            var isNotNullAndNotEmpty = !isNullOrEmpty;
            return isNotNullAndNotEmpty;
        }

        public WasFound<int> LastIndexOf(
            char character,
            string @string)
        {
            var lastIndexOrNotFound = this.LastIndexOf_OrNotFound(
                character,
                @string);

            var output = Internal.WasFound(lastIndexOrNotFound);
            return output;
        }

        public int LastIndexOf_OrNotFound(
            char character,
            string @string)
        {
            var lastIndexOf = @string.LastIndexOf(character);
            return lastIndexOf;
        }            

        public string Lower(string @string)
        {
            var output = @string.ToLowerInvariant();
            return output;
        }

        /// <summary>
        /// Appends the new-line separator to the string to make the string be a line.
        /// (Lines end with a new-line separator.)
        /// </summary>
        public string MakeIntoLine(
            string @string,
            string newLineSeparator)
        {
            var output = @string + newLineSeparator;
            return output;
        }

        /// <inheritdoc cref="MakeIntoLine(string, string)"/>
        public string MakeIntoLine(string @string)
        {
            return this.MakeIntoLine(
                @string,
                Instances.Strings.NewLine_ForEnvironment);
        }

        public StringBuilder New()
        {
            return new StringBuilder();
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

        public string Repeat(char character, int count)
        {
            var output = new string(character, count);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="L0053.IStringOperator.Append(string, string)"/>.
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

        public string ToIndex_Exclusive(
            int index,
            string @string)
        {
            var output = @string[..index];
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
        public WasFound<int> WasFound(int indexOrNotFound)
        {
            var wasFound = F0000.StringOperator.Instance.WasFound(indexOrNotFound);

            var output = N0000.WasFound.From(
                wasFound,
                indexOrNotFound);

            return output;
        }
    }
}