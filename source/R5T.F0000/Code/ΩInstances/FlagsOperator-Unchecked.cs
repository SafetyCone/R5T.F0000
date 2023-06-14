using System;


namespace R5T.F0000.Unchecked
{
    public class FlagsOperator : IFlagsOperator
    {
        #region Infrastructure

        public static IFlagsOperator Instance { get; } = new FlagsOperator();


        private FlagsOperator()
        {
        }

        #endregion
    }
}
