using System;
using System.Collections.Generic;

using Instances = R5T.F0000.Instances;


namespace System.Linq
{
    public static class CharacterExtensions
    {
        public static string Join(this IEnumerable<char> characters, string separator)
        {
            var output = Instances.CharacterOperator.Join(
                characters,
                separator);

            return output;
        }

        public static string Join(this IEnumerable<char> characters)
        {
            var output = Instances.CharacterOperator.Join(characters);
            return output;
        }

        /// <inheritdoc cref="R5T.F0000.ICharacterOperator.OrderAlphabetically(IEnumerable{char})"/>
        public static IEnumerable<char> OrderAlphabetically(this IEnumerable<char> characters)
        {
            var output = Instances.CharacterOperator.OrderAlphabetically(characters);
            return output;
        }

        /// <inheritdoc cref="R5T.F0000.ICharacterOperator.OrderNumerically(IEnumerable{char})"/>
        public static IEnumerable<char> OrderNumerically(this IEnumerable<char> characters)
        {
            var output = Instances.CharacterOperator.OrderNumerically(characters);
            return output;
        }
    }
}
