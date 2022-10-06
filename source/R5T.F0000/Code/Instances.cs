using System;

using R5T.Z0000;


namespace R5T.F0000
{
    public static class Instances
    {
        public static IArrayOperator ArrayOperator { get; } = F0000.ArrayOperator.Instance;
        public static IBooleanOperator BooleanOperator { get; } = F0000.BooleanOperator.Instance;
        public static ICharacterIndexes CharacterIndexes { get; } = Z0000.CharacterIndexes.Instance;
        public static ICharacterNames CharacterNames { get; } = Z0000.CharacterNames.Instance;
        public static ICharacters Characters { get; } = Z0000.Characters.Instance;
        public static ICharacterSets CharacterSets { get; } = Z0000.CharacterSets.Instance;
        public static ICommandLineArgumentsOperator CommandLineArgumentsOperator { get; } = F0000.CommandLineArgumentsOperator.Instance;
        public static ICommandLineOperator CommandLineOperator { get; } = F0000.CommandLineOperator.Instance;
        public static IComparisonOperator ComparisonOperator { get; } = F0000.ComparisonOperator.Instance;
        public static IComparisonResults ComparisonResults { get; } = F0000.ComparisonResults.Instance;
        public static IDateTimeOffsetOperator DateTimeOffsetOperator { get; } = F0000.DateTimeOffsetOperator.Instance;
        public static IDateTimeOperator DateTimeOperator { get; } = F0000.DateTimeOperator.Instance;
        public static IDescriptions Descriptions { get; } = F0000.Descriptions.Instance;
        public static IDictionaryOperator DictionaryOperator { get; } = F0000.DictionaryOperator.Instance;
        public static IEnumerableOperator EnumerableOperator { get; } = F0000.EnumerableOperator.Instance;
        public static IEnumerationOperator EnumerationOperator { get; } = F0000.EnumerationOperator.Instance;
        public static IEnvironmentOperator EnvironmentOperator { get; } = F0000.EnvironmentOperator.Instance;
        public static IExceptionMessageOperator ExceptionMessageOperator { get; } = F0000.ExceptionMessageOperator.Instance;
        public static IExceptionOperator ExceptionOperator { get; } = F0000.ExceptionOperator.Instance;
        public static IExecutablePathOperator ExecutablePathOperator { get; } = F0000.ExecutablePathOperator.Instance;
        public static IExitCodes ExitCodes { get; } = F0000.ExitCodes.Instance;
        public static IExitCodeOperator ExitCodeOperator { get; } = F0000.ExitCodeOperator.Instance;
        public static IFileExtensionOperator FileExtensionOperator { get; } = F0000.FileExtensionOperator.Instance;
        public static IFileNameOperator FileNameOperator { get; } = F0000.FileNameOperator.Instance;
        public static IFileOperator FileOperator { get; } = F0000.FileOperator.Instance;
        public static IFileSystemOperator FileSystemOperator { get; } = F0000.FileSystemOperator.Instance;
        public static IIndex Index { get; } = F0000.Index.Instance;
        public static IIndexOperator IndexOperator { get; } = F0000.IndexOperator.Instance;
        public static IIntegers Integers { get; } = F0000.Integers.Instance;
        public static IListOperator ListOperator { get; } = F0000.ListOperator.Instance;
        public static IMessages Messages { get; } = F0000.Messages.Instance;
        public static INamespacedTypeNameOperator NamespacedTypeNameOperator { get; } = F0000.NamespacedTypeNameOperator.Instance;
        public static INowOperator NowOperator { get; } = F0000.NowOperator.Instance;
        public static IObjectOperator ObjectOperator { get; } = F0000.ObjectOperator.Instance;
        public static ISearchPatterns SearchPatterns { get; } = F0000.SearchPatterns.Instance;
        public static ISearchPatternGenerator SearchPatternGenerator { get; } = F0000.SearchPatternGenerator.Instance;
        public static ISeeds Seeds { get; } = F0000.Seeds.Instance;
        public static ISourceCodeOperator SourceCodeOperator { get; } = F0000.SourceCodeOperator.Instance;
        public static IStackOperator StackOperator { get; } = F0000.StackOperator.Instance;
        public static IString String { get; } = F0000.String.Instance;
        public static IStringOperator StringOperator { get; } = F0000.StringOperator.Instance;
        public static IStrings Strings { get; } = Z0000.Strings.Instance;
        public static ITextOperator TextOperator { get; } = F0000.TextOperator.Instance;
        public static ITimeSpanOperator TimeSpanOperator { get; } = F0000.TimeSpanOperator.Instance;
        public static ITypeNameOperator TypeNameOperator { get; } = F0000.TypeNameOperator.Instance;
        public static ITypeOperator TypeOperator { get; } = F0000.TypeOperator.Instance;
        public static IUrlOperator UrlOperator { get; } = F0000.UrlOperator.Instance;
        public static IVersionOperator VersionOperator { get; } = F0000.VersionOperator.Instance;
        public static IVersions Versions { get; } = F0000.Versions.Instance;
        public static IWasFoundOperator WasFoundOperator { get; } = F0000.WasFoundOperator.Instance;
        public static IXmlNamespaceNames XmlNamespaceNames { get; } = F0000.XmlNamespaceNames.Instance;
        public static IXmlOperator XmlOperator { get; } = F0000.XmlOperator.Instance;
        public static IXmlStrings XmlStrings { get; } = F0000.XmlStrings.Instance;
        public static IXmlWriterSettingsOperator XmlWriterSettingsOperator { get; } = F0000.XmlWriterSettingsOperator.Instance;
        public static IXPathGenerator XPathGenerator { get; } = F0000.XPathGenerator.Instance;
    }
}
