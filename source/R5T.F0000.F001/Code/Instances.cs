using System;


namespace R5T.F0000.F001
{
    public static class Instances
    {
        public static IDateOnlyOperator DateOnlyOperator { get; } = F001.DateOnlyOperator.Instance;
        public static F0000.IDateOperator F0000_DateOperator { get; } = F0000.DateOperator.Instance;
        public static IDateOperator DateOperator { get; } = F001.DateOperator.Instance;
        public static L0072.IDateOperator DateOperator_L0072 { get; } = L0072.DateOperator.Instance;
        public static IDateTimeOperator DateTimeOperator { get; } = F001.DateTimeOperator.Instance;
        public static ITimeOnlyOperator TimeOnlyOperator { get; } = F001.TimeOnlyOperator.Instance;
    }
}