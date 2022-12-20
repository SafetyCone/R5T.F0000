using System;


namespace R5T.F0000
{
    public class InputArgumentOperator : IInputArgumentOperator
    {
        #region Infrastructure

        public static IInputArgumentOperator Instance { get; } = new InputArgumentOperator();


        private InputArgumentOperator()
        {
        }

        #endregion
    }
}
