using System;


namespace R5T.F0000
{
    public class GuidOperator : IGuidOperator
    {
        #region Infrastructure

        public static GuidOperator Instance { get; } = new();

        private GuidOperator()
        {
        }

        #endregion
    }
}
