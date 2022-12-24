using System;


namespace R5T.F0000
{
    public class CurrentDirectoryOperator : ICurrentDirectoryOperator
    {
        #region Infrastructure

        public static ICurrentDirectoryOperator Instance { get; } = new CurrentDirectoryOperator();


        private CurrentDirectoryOperator()
        {
        }

        #endregion
    }
}
