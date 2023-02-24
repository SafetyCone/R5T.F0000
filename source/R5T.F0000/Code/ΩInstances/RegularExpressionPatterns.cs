using System;


namespace R5T.F0000
{
    public class RegularExpressionPatterns : IRegularExpressionPatterns
    {
        #region Infrastructure

        public static IRegularExpressionPatterns Instance { get; } = new RegularExpressionPatterns();


        private RegularExpressionPatterns()
        {
        }

        #endregion
    }
}
