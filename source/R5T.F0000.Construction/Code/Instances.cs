using System;

using R5T.T0140.Z001;
using R5T.Z0004;


namespace R5T.F0000.Construction
{
    public static class Instances
    {
        public static ICommandLineOperations CommandLineOperations { get; } = Construction.CommandLineOperations.Instance;
        public static IDotnetCommandLineOperator DotnetCommandLineOperator { get; } = Construction.DotnetCommandLineOperator.Instance;
        public static IDurations Durations { get; } = Construction.Durations.Instance;
        public static IExamples Examples { get; } = Z0004.Examples.Instance;
        public static IExampleTypes ExampleTypes { get; } = T0140.Z001.ExampleTypes.Instance;
        public static IExecutableFilePaths ExecutableFilePaths { get; } = Construction.ExecutableFilePaths.Instance;
        public static IExecutableNames ExecutableNames { get; } = Construction.ExecutableNames.Instance;
        public static IFileOperations FileOperations { get; } = Construction.FileOperations.Instance;
        public static IGuidOperator GuidOperator { get; } = F0000.GuidOperator.Instance;
        public static ITypeOperations TypeOperations { get; } = Construction.TypeOperations.Instance;
        public static ITypeOperator TypeOperator { get; } = F0000.TypeOperator.Instance;
        public static IXmlFileOperator XmlFileOperator { get; } = F0000.XmlFileOperator.Instance;
        public static IXmlOperations XmlOperations { get; } = Construction.XmlOperations.Instance;
        public static IXmlOperator XmlOperator { get; } = F0000.XmlOperator.Instance;
    }
}