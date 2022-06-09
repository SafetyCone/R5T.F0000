using System;


namespace R5T.F0000
{
    public class IndexOperator : IIndexOperator
    {
        #region Infrastructure

        public static IndexOperator Instance { get; } = new();

        private IndexOperator()
        {
        }

        #endregion
    }
}
