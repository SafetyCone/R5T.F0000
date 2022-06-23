using System;

using R5T.Z0004;


namespace R5T.F0000.Construction
{
    public static class Instances
    {
        public static IExample Example { get; } = Z0004.Example.Instance;
        public static IGuidOperator GuidOperator { get; } = F0000.GuidOperator.Instance;

        public static IGuidFormatDemonstration GuidFormatDemonstration { get; } = Construction.GuidFormatDemonstration.Instance;
    }
}