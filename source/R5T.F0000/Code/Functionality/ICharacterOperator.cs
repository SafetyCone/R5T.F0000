using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;

using Glossary = R5T.Y0000.Glossary;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public interface ICharacterOperator
    {
        /// <summary>
        /// Describes a character with its string representation, three-digit numeric value, and name. Example: 'b': 062, "lower-case b".
        /// </summary>
        public string Describe(char character)
        {
            var index = this.GetIndex(character);
            var name = this.GetCharacterName(character);

            var output = $"'{character}': {index:000}, \"{name}\"";
            return output;
        }

        public string Describe(params char[] characters)
        {
            var output = this.Describe(characters.AsEnumerable());
            return output;
        }

        public string Describe(IEnumerable<char> characters)
        {
            var strings = characters
                .Select(xChar => this.Describe(xChar))
                ;

            var output = System.String.Join(Instances.Characters.NewLine, strings);
            return output;
        }

        public char[] GetAsciiCharactersWhere(
            Func<char, bool> predicate)
        {
            var output = this.GetCharactersWhere(
                Instances.CharacterIndexes.Default_FirstIndex,
                Instances.CharacterIndexes.ASCII_LastIndex,
                predicate);

            return output;
        }

        public IEnumerable<char> GetCharacterRange(
            int firstIndex_Inclusive,
            int lastIndex_Inclusive)
        {
            var lastIndex_Exclusive = Instances.IndexOperator.GetLastExclusiveIndex(lastIndex_Inclusive);

            for (int i = 0; i < lastIndex_Exclusive; i++)
            {
                var output = Convert.ToChar(i);
                yield return output;
            }
        }

        public char[] GetCharactersWhere(
            int firstIndex_Inclusive,
            int lastIndex_Inclusive,
            Func<char, bool> predicate)
        {
            var output = this.GetCharacterRange(
                firstIndex_Inclusive,
                lastIndex_Inclusive)
                .Where(predicate)
                .ToArray();

            return output;
        }

        public string GetCharacterName(char character)
        {
            var characterName = Instances.CharacterNames;

            // Characters are in numeric order ("tab", #009, comes before "carriage-return, #013).
            return character switch
            {
                '\0' => characterName.Null, // 000
                '' => characterName.StartOfHeading, // 001
                '' => characterName.StartOfText, // 002
                '' => characterName.EndOfText, // 003
                '' => characterName.EndOfTransmission, // 004
                '' => characterName.Enquiry, // 005
                '' => characterName.Acknowledgment, // 006
                '' => characterName.Bell, // 007
                '' => characterName.Backspace, // 008
                '\t' => characterName.Tab, // 009
                '\n' => characterName.LineFeed, // 010
                '' => characterName.VerticalTab, // 011
                '' => characterName.FormFeed, // 012
                '\r' => characterName.CarriageReturn, // 013
                '' => characterName.ShiftOut, // 014
                '' => characterName.ShiftIn, // 015
                '' => characterName.DataLineEscape, // 016
                '' => characterName.DeviceControl1, // 017
                '' => characterName.DeviceControl2, // 018
                '' => characterName.DeviceControl3, // 019
                '' => characterName.DeviceControl4, // 020
                '' => characterName.NegativeAcknowledgment, // 021
                '' => characterName.SynchronousIdle, // 022
                '' => characterName.EndOfTransmitBlock, // 023
                '' => characterName.Cancel, // 024
                '' => characterName.EndOfMedium, // 025
                '' => characterName.Substitute, // 026
                '' => characterName.Escape, // 027
                '' => characterName.FileSeparator, // 028
                '' => characterName.GroupSeparator, // 029
                '' => characterName.RecordSeparator, // 030
                '' => characterName.UnitSeparator, // 031
                ' ' => characterName.Space, // 032
                '!' => characterName.ExclamationMark, // 033,
                '"' => characterName.DoubleQuote, // 034
                '#' => characterName.Pound, // 035
                '$' => characterName.Dollar, // 036
                '%' => characterName.Percent, // 037
                '&' => characterName.Ampersand, // 038
                '\'' => characterName.SingleQuote, // 039 
                '(' => characterName.OpenParenthesis, // 040
                ')' => characterName.CloseParenthesis, // 041
                '*' => characterName.Asterix, // 042
                '+' => characterName.Plus, // 043
                ',' => characterName.Comma, // 044
                '-' => characterName.Hyphen, // 045
                '.' => characterName.Period, // 046
                '/' => characterName.Slash, // 047

                '0' => characterName.Zero, // 048
                '1' => characterName.One, // 049
                '2' => characterName.Two, // 050
                '3' => characterName.Three, // 051
                '4' => characterName.Four, // 052
                '5' => characterName.Five, // 053
                '6' => characterName.Six, // 054
                '7' => characterName.Seven, // 055
                '8' => characterName.Eight, // 056
                '9' => characterName.Nine, // 057

                ':' => characterName.Colon, // 058
                ';' => characterName.Semicolon, // 059
                '<' => characterName.LessThan, // 060
                '=' => characterName.Equals, // 061
                '>' => characterName.GreaterThan, // 062
                '?' => characterName.QuestionMark, // 063
                '@' => characterName.At, // 064

                '[' => characterName.OpenBracket, // 091
                '\\' => characterName.Backslash, // 092
                ']' => characterName.CloseBracket, // 093
                '^' => characterName.Caret, // 094
                '_' => characterName.Underscore, // 095
                '`' => characterName.Backtick, // 096

                '{' => characterName.OpenBrace, // 0123
                '|' => characterName.Pipe, // 124
                '}' => characterName.CloseBrace, // 0125
                '~' => characterName.Tilde, // 0126
                '' => characterName.Delete, // 0127

                '\x85' => characterName.NextLine, // 133
                ' ' => characterName.NonBreakingSpace, // 160

                _ => characterName.Unknown, // No number, place-holder value that can be removed once ALL characters are present.
            };
        }

        /// <summary>
        /// Chooses <see cref="GetAsciiCharactersWhere(Func{char, bool})"/> as the default.
        /// </summary>
        public char[] GetCharactersWhere(
            Func<char, bool> predicate)
        {
            var output = this.GetAsciiCharactersWhere(predicate);
            return output;
        }

        /// <summary>
        /// Converts the character to its integer index.
        /// </summary>
        public int GetIndex(char character)
        {
            var output = Convert.ToInt32(character);
            return output;
        }

        public char[] GetUnextendedAsciiCharactersWhere(
            Func<char, bool> predicate)
        {
            var output = this.GetCharactersWhere(
                Instances.CharacterIndexes.Default_FirstIndex,
                Instances.CharacterIndexes.ASCII_Unextended_LastIndex,
                predicate);

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Alphanumeric" path="/definition"/>
        /// </summary>
        public bool IsAlphanumeric(char character)
        {
            var output = Char.IsLetterOrDigit(character);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="IsUppercase(char)"/>.
        /// </summary>
        public bool IsCapitalized(char character)
        {
            var output = this.IsUppercase(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Character" path="/definition"/>
        /// </summary>
        public bool IsCharacter(char character)
        {
            return true;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Control" path="/definition"/>
        /// </summary>
        public bool IsControl(char character)
        {
            var output = Char.IsControl(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Digit" path="/definition"/>
        /// </summary>
        public bool IsDigit(char character)
        {
            var output = Char.IsDigit(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Letter" path="/definition"/>
        /// </summary>
        public bool IsLetter(char character)
        {
            var output = Char.IsLetter(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Alphanumeric" path="/definition"/>
        /// </summary>
        public bool IsLetterOrDigit(char character)
        {
            var output = Char.IsLetterOrDigit(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Lowercase" path="/definition"/>
        /// </summary>
        public bool IsLowercase(char character)
        {
            var output = Char.IsLower(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.None" path="/definition"/>
        /// </summary>
        public bool IsNone(char character)
        {
            return false;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Number" path="/definition"/>
        /// </summary>
        public bool IsNumber(char character)
        {
            var output = Char.IsNumber(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Punctuation" path="/definition"/>
        /// </summary>
        public bool IsPunctuation(char character)
        {
            var output = Char.IsPunctuation(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Separator" path="/definition"/>
        /// </summary>
        public bool IsSeparator(char character)
        {
            var output = Char.IsSeparator(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Symbol" path="/definition"/>
        /// </summary>
        public bool IsSymbol(char character)
        {
            var output = Char.IsSymbol(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Uppercase" path="/definition"/>
        /// </summary>
        public bool IsUppercase(char character)
        {
            var output = Char.IsUpper(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Whitespace" path="/definition"/>
        /// </summary>
        public bool IsWhitespace(char character)
        {
            var output = Char.IsWhiteSpace(character);
            return output;
        }

        public string Join(IEnumerable<char> characters, string separator)
        {
            var characterStrings = characters
                .Select(character => character.ToString())
                ;

            var output = Instances.StringOperator.Join(
                separator,
                characterStrings);

            return output;
        }

        public string Join(IEnumerable<char> characters)
        {
            var separator = Instances.Strings.CommaSeparatedListSpacedSeparator;

            var output = this.Join(characters, separator);
            return output;
        }

        public string List(
            string separator,
            string ifEmptyDescription,
            params char[] characters)
        {
            var output = this.List(
                separator,
                ifEmptyDescription,
                characters.AsEnumerable());

            return output;
        }

        public string List(
            string separator,
            params char[] characters)
        {
            var output = this.List(
                separator,
                characters.AsEnumerable());

            return output;
        }

        public string List(params char[] characters)
        {
            var output = this.List(characters.AsEnumerable());

            return output;
        }

        public string List(
            string separator,
            string ifEmptyDescription,
            IEnumerable<char> characters)
        {
            if (characters.None())
            {
                return ifEmptyDescription;
            }

            var output = System.String.Join(separator, characters);
            return output;
        }

        public string List(
            string separator,
            IEnumerable<char> characters)
        {
            var output = this.List(
                separator,
                Instances.Descriptions.IfEmpty,
                characters);

            return output;
        }

        public string List(IEnumerable<char> characters)
        {
            var output = this.List(
                Instances.Strings.CommaSeparatedListSpacedSeparator,
                Instances.Descriptions.IfEmpty,
                characters);

            return output;
        }

        public IEnumerable<char> OrderAlphabetically(IEnumerable<char> characters)
        {
            var output = characters.OrderBy(x => x);
            return output;
        }

        /// <summary>
        /// Chooses the invariant lowering operation as default.
        /// </summary>
        public char ToLower(char character)
        {
            var output = Char.ToLowerInvariant(character);
            return output;
        }

        /// <summary>
        /// Chooses the invariant uppering operation as default.
        /// </summary>
        public char ToUpper(char character)
        {
            var output = Char.ToUpperInvariant(character);
            return output;
        }
    }
}
