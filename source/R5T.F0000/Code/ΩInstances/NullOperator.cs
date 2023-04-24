using System;


namespace R5T.F0000
{
    public class NullOperator : INullOperator
    {
        #region Infrastructure

        public static INullOperator Instance { get; } = new NullOperator();


        private NullOperator()
        {
        }

        #endregion
    }
}
