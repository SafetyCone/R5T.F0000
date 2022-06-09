using System;

using R5T.Z0000;


namespace R5T.F0000
{
    public static class Instances
    {
        public static ICharacterIndexes CharacterIndexes { get; } = Z0000.CharacterIndexes.Instance;
        public static ICharacterNames CharacterNames { get; } = Z0000.CharacterNames.Instance;
        public static IIndexOperator IndexOperator { get; } = F0000.IndexOperator.Instance;
    }
}
