using System;


namespace R5T.F0000
{
	public class ExceptionOperator : IExceptionOperator
	{
		#region Infrastructure

	    public static IExceptionOperator Instance { get; } = new ExceptionOperator();

	    private ExceptionOperator()
	    {
        }

	    #endregion
	}
}


namespace R5T.F0000.Internal
{
    public class ExceptionOperator : IExceptionOperator
    {
        #region Infrastructure

        public static IExceptionOperator Instance { get; } = new ExceptionOperator();

        private ExceptionOperator()
        {
        }

        #endregion
    }
}