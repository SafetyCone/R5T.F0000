using System;

using R5T.Z0004;


namespace R5T.F0000.Construction
{
    public static class Instances
    {
        public static IExamples Examples { get; } = Z0004.Examples.Instance;
        public static IGuidOperator GuidOperator { get; } = F0000.GuidOperator.Instance;

        public static IGuidFormatDemonstration GuidFormatDemonstration { get; } = Construction.GuidFormatDemonstration.Instance;
    }
}