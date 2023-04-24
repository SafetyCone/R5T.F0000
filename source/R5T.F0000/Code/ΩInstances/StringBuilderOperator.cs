using System;


namespace R5T.F0000
{
    public class StringBuilderOperator : IStringBuilderOperator
    {
        #region Infrastructure

        public static IStringBuilderOperator Instance { get; } = new StringBuilderOperator();


        private StringBuilderOperator()
        {
        }

        #endregion
    }
}
