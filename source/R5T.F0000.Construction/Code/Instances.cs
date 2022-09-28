using System;

using R5T.Z0004;


namespace R5T.F0000.Construction
{
    public static class Instances
    {
        public static ICommandLineOperations CommandLineOperations { get; } = Construction.CommandLineOperations.Instance;
        public static IDotnetCommandLineOperator DotnetCommandLineOperator { get; } = Construction.DotnetCommandLineOperator.Instance;
        public static IDurations Durations { get; } = Construction.Durations.Instance;
        public static IExamples Examples { get; } = Z0004.Examples.Instance;
        public static IExecutableFilePaths ExecutableFilePaths { get; } = Construction.ExecutableFilePaths.Instance;
        public static IExecutableNames ExecutableNames { get; } = Construction.ExecutableNames.Instance;
        public static IGuidOperator GuidOperator { get; } = F0000.GuidOperator.Instance;
    }
}