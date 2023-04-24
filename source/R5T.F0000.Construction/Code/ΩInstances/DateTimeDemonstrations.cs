using System;


namespace R5T.F0000.Construction
{
    public class DateTimeDemonstrations : IDateTimeDemonstrations
    {
        #region Infrastructure

        public static IDateTimeDemonstrations Instance { get; } = new DateTimeDemonstrations();


        private DateTimeDemonstrations()
        {
        }

        #endregion
    }
}
