using System;


namespace R5T.F0000
{
    public class DoubleOperator : IDoubleOperator
    {
        #region Infrastructure

        public static IDoubleOperator Instance { get; } = new DoubleOperator();


        private DoubleOperator()
        {
        }

        #endregion
    }
}
