using System;
using System.Collections.Generic;

using Instances = R5T.F0000.Instances;


namespace System.Linq
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> OrderChronologically(this IEnumerable<DateTime> dates)
        {
            var output = Instances.DateTimeOperator.OrderChronologically(dates);
            return output;
        }

        public static IEnumerable<DateTime> OrderReverseChronologically(this IEnumerable<DateTime> dates)
        {
            var output = Instances.DateTimeOperator.OrderReverseChronologically(dates);
            return output;
        }
    }
}


namespace R5T.F0000.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToYYYYMMDD(this DateTime value)
        {
            var output = Instances.DateOperator.ToString_YYYYMMDD(value);
            return output;
        }

        public static string ToYYYYMMDD_HHMMSS(this DateTime value)
        {
            var output = Instances.DateOperator.ToString_YYYYMMDD_HHMMSS(value);
            return output;
        }
    }
}