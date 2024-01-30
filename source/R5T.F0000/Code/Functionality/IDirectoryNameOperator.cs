using System;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IDirectoryNameOperator : IFunctionalityMarker,
        L0066.IDirectoryNameOperator
    {
        public string Get_DatedDirectoryName(DateTime date)
        {
            var yyyymmdd = DateOperator.Instance.ToString_YYYYMMDD(date);

            // Any YYYYMMDD is already a valid directory name.
            return yyyymmdd;
        }

        public string Get_DateTimedDirectoryName(DateTime dateTime)
        {
            var yyyymmdd_hhmmss = DateOperator.Instance.ToString_YYYYMMDD_HHMMSS(dateTime);

            // Any yyyymmdd_hhmmss is already a valid directory name.
            return yyyymmdd_hhmmss;
        }
    }
}
