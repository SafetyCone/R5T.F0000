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

        public static IEnumerable<char> OrderAlphabetically(this IEnumerable<char> characters)
        {
            var output = Instances.CharacterOperator.OrderAlphabetically(characters);
            return output;
        }
    }
}
