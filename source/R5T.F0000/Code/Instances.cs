using System;

using R5T.Z0000;


namespace R5T.F0000
{
    public static class Instances
    {
        public static IArrayOperator ArrayOperator { get; } = F0000.ArrayOperator.Instance;
        public static ICharacterIndexes CharacterIndexes { get; } = Z0000.CharacterIndexes.Instance;
        public static ICharacterNames CharacterNames { get; } = Z0000.CharacterNames.Instance;
        public static ICharacters Characters { get; } = Z0000.Characters.Instance;
        public static ICharacterSets CharacterSets { get; } = Z0000.CharacterSets.Instance;
        public static ICommandLineArgumentsOperator CommandLineArgumentsOperator { get; } = F0000.CommandLineArgumentsOperator.Instance;
        public static IDescriptions Descriptions { get; } = F0000.Descriptions.Instance;
        public static IDictionaryOperator DictionaryOperator { get; } = F0000.DictionaryOperator.Instance;
        public static IEnumerableOperator EnumerableOperator { get; } = F0000.EnumerableOperator.Instance;
        public static IExecutablePathOperator ExecutablePathOperator { get; } = F0000.ExecutablePathOperator.Instance;
        public static IFileExtensionOperator FileExtensionOperator { get; } = F0000.FileExtensionOperator.Instance;
        public static IFileNameOperator FileNameOperator { get; } = F0000.FileNameOperator.Instance;
        public static IIndex Index { get; } = F0000.Index.Instance;
        public static IIndexOperator IndexOperator { get; } = F0000.IndexOperator.Instance;
        public static IListOperator ListOperator { get; } = F0000.ListOperator.Instance;
        public static ISeeds Seeds { get; } = F0000.Seeds.Instance;
        public static ISourceCodeOperator SourceCodeOperator { get; } = F0000.SourceCodeOperator.Instance;
        public static IString String { get; } = F0000.String.Instance;
        public static IStringOperator StringOperator { get; } = F0000.StringOperator.Instance;
        public static IStrings Strings { get; } = Z0000.Strings.Instance;
        public static ITextOperator TextOperator { get; } = F0000.TextOperator.Instance;
    }
}
