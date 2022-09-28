using System;

using R5T.Z0004;


namespace R5T.F0000.Q000
{
    public static class Instances
    {
        public static IExamples Examples { get; } = Z0004.Examples.Instance;
        public static IGuidOperator GuidOperator { get; } = F0000.GuidOperator.Instance;

        public static IBooleanDemonstrations BooleanDemonstrations { get; } = Q000.BooleanDemonstrations.Instance;
        public static IGuidFormatDemonstration GuidFormatDemonstration { get; } = Q000.GuidFormatDemonstration.Instance;
        public static IXmlDemonstrations XmlDemonstrations { get; } = Q000.XmlDemonstrations.Instance;
    }
}