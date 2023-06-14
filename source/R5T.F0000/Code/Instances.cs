using System;

using R5T.Z0000;


namespace R5T.F0000
{
    public static class Instances
    {
        public static IArrayOperator ArrayOperator => F0000.ArrayOperator.Instance;
        public static IBooleanOperator BooleanOperator => F0000.BooleanOperator.Instance;
        public static ICharacterIndexes CharacterIndexes => Z0000.CharacterIndexes.Instance;
        public static ICharacterNames CharacterNames => Z0000.CharacterNames.Instance;
        public static ICharacterOperator CharacterOperator => F0000.CharacterOperator.Instance;
        public static ICharacters Characters => Z0000.Characters.Instance;
        public static ICharacterSets CharacterSets => Z0000.CharacterSets.Instance;
        public static ICommandLineArgumentsOperator CommandLineArgumentsOperator => F0000.CommandLineArgumentsOperator.Instance;
        public static ICommandLineOperator CommandLineOperator => F0000.CommandLineOperator.Instance;
        public static IComparisonOperator ComparisonOperator => F0000.ComparisonOperator.Instance;
        public static IComparisonResults ComparisonResults => F0000.ComparisonResults.Instance;
        public static IDateOperator DateOperator => F0000.DateOperator.Instance;
        public static IDateTimeFormats DateTimeFormats => F0000.DateTimeFormats.Instance;
        public static IDateTimeFormatTemplates DateTimeFormatTemplates => F0000.DateTimeFormatTemplates.Instance;
        public static IDateTimeOffsetOperator DateTimeOffsetOperator => F0000.DateTimeOffsetOperator.Instance;
        public static IDateTimeOperator DateTimeOperator => F0000.DateTimeOperator.Instance;
        public static IDescriptions Descriptions => F0000.Descriptions.Instance;
        public static IDictionaryOperator DictionaryOperator => F0000.DictionaryOperator.Instance;
        public static IDirectoryInfoOperator DirectoryInfoOperator => F0000.DirectoryInfoOperator.Instance;
        public static IDoubleOperator DoubleOperator => F0000.DoubleOperator.Instance;
        public static IEnumerableOperator EnumerableOperator => F0000.EnumerableOperator.Instance;
        public static IEnumerationOperator EnumerationOperator => F0000.EnumerationOperator.Instance;
        public static Unchecked.IEnumerationOperator EnumerationOperator_Unchecked => Unchecked.EnumerationOperator.Instance;
        public static IEnvironmentOperator EnvironmentOperator => F0000.EnvironmentOperator.Instance;
        public static IExceptionMessageOperator ExceptionMessageOperator => F0000.ExceptionMessageOperator.Instance;
        public static IExceptionOperator ExceptionOperator => F0000.ExceptionOperator.Instance;
        public static IExecutablePathOperator ExecutablePathOperator => F0000.ExecutablePathOperator.Instance;
        public static IExitCodes ExitCodes => F0000.ExitCodes.Instance;
        public static IExitCodeOperator ExitCodeOperator => F0000.ExitCodeOperator.Instance;
        public static IFileExtensionOperator FileExtensionOperator => F0000.FileExtensionOperator.Instance;
        public static IFileExtensions FileExtensions => F0000.FileExtensions.Instance;
        public static IFileNameOperator FileNameOperator => F0000.FileNameOperator.Instance;
        public static IFileOperator FileOperator => F0000.FileOperator.Instance;
        public static IFileStreamOperator FileStreamOperator => F0000.FileStreamOperator.Instance;
        public static IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static IFormatProviders FormatProviders => F0000.FormatProviders.Instance;
        public static IGuidOperator GuidOperator => F0000.GuidOperator.Instance;
        public static IIndex Index => F0000.Index.Instance;
        public static IIndexOperator IndexOperator => F0000.IndexOperator.Instance;
        public static IIntegers Integers => F0000.Integers.Instance;
        public static IListOperator ListOperator => F0000.ListOperator.Instance;
        public static IMemoryStreamOperator MemoryStreamOperator => F0000.MemoryStreamOperator.Instance;
        public static IMessages Messages => F0000.Messages.Instance;
        public static INamespacedTypeNameOperator NamespacedTypeNameOperator => F0000.NamespacedTypeNameOperator.Instance;
        public static INowOperator NowOperator => F0000.NowOperator.Instance;
        public static IObjectOperator ObjectOperator => F0000.ObjectOperator.Instance;
        public static IPathOperator PathOperator => F0000.PathOperator.Instance;
        public static ISearchPatterns SearchPatterns => F0000.SearchPatterns.Instance;
        public static ISearchPatternGenerator SearchPatternGenerator => F0000.SearchPatternGenerator.Instance;
        public static ISeeds Seeds => F0000.Seeds.Instance;
        public static ISourceCodeOperator SourceCodeOperator => F0000.SourceCodeOperator.Instance;
        public static IStackOperator StackOperator => F0000.StackOperator.Instance;
        public static IStreamWriterOperator StreamWriterOperator => F0000.StreamWriterOperator.Instance;
        public static IString String => F0000.String.Instance;
        public static IStringBuilderOperator StringBuilderOperator => F0000.StringBuilderOperator.Instance;
        public static IStringOperator StringOperator => F0000.StringOperator.Instance;
        public static IStrings Strings => F0000.Strings.Instance;
        public static ISyncOverAsyncOperator SyncOverAsyncOperator => F0000.SyncOverAsyncOperator.Instance;
        public static ITextOperator TextOperator => F0000.TextOperator.Instance;
        public static ITimeSpanOperator TimeSpanOperator => F0000.TimeSpanOperator.Instance;
        public static ITypeNameAffixes TypeNameAffixes => F0000.TypeNameAffixes.Instance;
        public static ITypeNameOperator TypeNameOperator => F0000.TypeNameOperator.Instance;
        public static ITypeOperator TypeOperator => F0000.TypeOperator.Instance;
        public static ITypes Types => F0000.Types.Instance;
        public static IUrlOperator UrlOperator => F0000.UrlOperator.Instance;
        public static IValues Values => F0000.Values.Instance;
        public static IVersionOperator VersionOperator => F0000.VersionOperator.Instance;
        public static IVersions Versions => F0000.Versions.Instance;
        public static IWasFoundOperator WasFoundOperator => F0000.WasFoundOperator.Instance;
        public static IXElementOperator XElementOperator => F0000.XElementOperator.Instance;
        public static IXmlNamespaceNames XmlNamespaceNames => F0000.XmlNamespaceNames.Instance;
        public static IXmlOperator XmlOperator => F0000.XmlOperator.Instance;
        public static IXmlStrings XmlStrings => F0000.XmlStrings.Instance;
        public static IXmlWriterSettingsOperator XmlWriterSettingsOperator => F0000.XmlWriterSettingsOperator.Instance;
        public static IXPathGenerator XPathGenerator => F0000.XPathGenerator.Instance;
    }
}
