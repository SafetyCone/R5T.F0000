using System;

using R5T.T0131;


namespace R5T.F0000
{
    [ValuesMarker]
    public partial interface IDateTimeFormatTemplates : IValuesMarker
    {
        public string YYYYMMDD_HHMMSS => $"{{0:{Instances.DateTimeFormats.YYYYMMDD_HHMMSS}}}";
        public string YYYYMMDD_HHMMSS_Dashed => $"{{0:{Instances.DateTimeFormats.YYYYMMDD_HHMMSS_Dashed}}}";
    }
}
