using System;

using R5T.Z0000;


namespace R5T.F0000
{
    public static class Instances
    {
        public static IArrayOperator ArrayOperator { get; } = F0000.ArrayOperator.Instance;
        public static ICharacterIndexes CharacterIndexes { get; } = Z0000.CharacterIndexes.Instance;
        public static ICharacterNames CharacterNames { get; } = Z0000.CharacterNames.Instance;
        public static IDescriptions Descriptions { get; } = F0000.Descriptions.Instance;
        public static IEnumerableOperator EnumerableOperator { get; } = F0000.EnumerableOperator.Instance;
        public static IIndex Index { get; } = F0000.Index.Instance;
        public static IIndexOperator IndexOperator { get; } = F0000.IndexOperator.Instance;
        public static IString String { get; } = F0000.String.Instance;
        public static IStrings Strings { get; } = Z0000.Strings.Instance;
    }
}
