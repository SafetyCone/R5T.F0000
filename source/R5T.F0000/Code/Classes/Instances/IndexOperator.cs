using System;


namespace R5T.F0000
{
    public class IndexOperator : IIndexOperator
    {
        #region Infrastructure

        public static IIndexOperator Instance { get; } = new IndexOperator();

        private IndexOperator()
        {
        }

        #endregion
    }
}
