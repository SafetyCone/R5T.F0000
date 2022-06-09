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
                '\t' => characterName.Tab, // 009
                '\n' => characterName.LineFeed, // 010
                '' => characterName.VerticalTab, // 011
                '' => characterName.FormFeed, // 012
                '\r' => characterName.CarriageReturn, // 013
                ' ' => characterName.Space, // 032
                '\x85' => characterName.NextLine, // 133
                ' ' => characterName.NonBreakingSpace, // 160

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
