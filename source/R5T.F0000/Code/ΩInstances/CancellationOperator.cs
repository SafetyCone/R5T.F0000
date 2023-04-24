using System;


namespace R5T.F0000
{
    public class CancellationOperator : ICancellationOperator
    {
        #region Infrastructure

        public static ICancellationOperator Instance { get; } = new CancellationOperator();


        private CancellationOperator()
        {
        }

        #endregion
    }
}
