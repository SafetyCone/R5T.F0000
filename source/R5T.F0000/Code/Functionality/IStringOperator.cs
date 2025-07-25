using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using R5T.L0089.T000;
using R5T.T0132;
using R5T.T0143;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public interface IStringOperator : IFunctionalityMarker,
        L0053.IStringOperator
	{
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public new Internal.IStringOperator _Internal => Internal.StringOperator.Instance;

        [Ignore]
        public L0053.IStringOperator _L0053 => L0053.StringOperator.Instance;


#pragma warning restore IDE1006 // Naming Styles



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
        /// This must duplicate <see cref="F10Y.L0000.IListOperator.Get_First{T}(IList{T})"/> because string does not actually implement <see cref="IList{T}"/> of <see cref="char"/>
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
        /// This must duplicate <see cref="L0066.IListOperator.Get_Second{T}(IList{T})"/> because string does not actually implement <see cref="IList{T}"/> of <see cref="char"/>
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

        public new int Get_LastIndexOf(
            char character,
            string @string)
        {
            var lastIndexWasFound = this.LastIndexOf(
                character,
                @string);

            return Instances.WasFoundOperator.Get_Result_OrExceptionIfNotFound(
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
        /// Chooses <see cref="L0066.IStringOperator.Get_Substring_From_Exclusive(int, string)"/> as the default.
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
        /// A quality-of-life overload for <see cref="L0066.IStringOperator.Is_NotNullOrEmpty(string)"/>.
        /// </summary>
        public bool HasValue(string @string)
        {
            var output = this.Is_NotNullOrEmpty(@string);
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

            var output = _Internal.WasFound(indexOrNotFound);
            return output;
        }

        public WasFound<int> IndexOf(
            char character,
            string @string)
        {
            var indexOrNotFound = this.IndexOf_OrNotFound(
                character,
                @string);

            var output = _Internal.WasFound(indexOrNotFound);
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

            var output = _Internal.WasFound(indexOrNotFound);
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

            var output = _Internal.WasFound(indexOrNotFound);
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

        public WasFound<int> LastIndexOf(
            char character,
            string @string)
        {
            var lastIndexOrNotFound = this.LastIndexOf_OrNotFound(
                character,
                @string);

            var output = _Internal.WasFound(lastIndexOrNotFound);
            return output;
        }

        public int LastIndexOf_OrNotFound(
            char character,
            string @string)
        {
            var lastIndexOf = @string.LastIndexOf(character);
            return lastIndexOf;
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

        /// <summary>
        /// Quality-of-life overload for <see cref="L0066.IStringOperator.Append(string, string)"/>.
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

            var output = L0089.T000.WasFound.From(
                wasFound,
                indexOrNotFound);

            return output;
        }
    }
}