using System;


namespace R5T.F0000
{
    public class GuidOperator : IGuidOperator
    {
        #region Infrastructure

        public static IGuidOperator Instance { get; } = new GuidOperator();

        private GuidOperator()
        {
        }

        #endregion
    }
}
