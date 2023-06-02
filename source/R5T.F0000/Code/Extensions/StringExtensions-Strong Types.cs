using System;


namespace R5T.F0000.StrongType.Extensions
{
    public static class StringExtensions
    {
        public static Guid ToGuid(this string value)
        {
            var output = Instances.GuidOperator.Parse(value);
            return output;
        }
    }
}
