using System;


namespace R5T.F0000.Implementations
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
