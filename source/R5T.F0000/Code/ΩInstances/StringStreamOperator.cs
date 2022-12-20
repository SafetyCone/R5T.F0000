using System;


namespace R5T.F0000
{
    public class StringStreamOperator : IStringStreamOperator
    {
        #region Infrastructure

        public static IStringStreamOperator Instance { get; } = new StringStreamOperator();


        private StringStreamOperator()
        {
        }

        #endregion
    }
}
