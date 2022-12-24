using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IDateTimeFormats : IValuesMarker
	{
		public string YYYYMMDD => "yyyyMMdd";
        public string YYYY_MM_DD_Dashed => "yyyy-MM-dd";
    }
}