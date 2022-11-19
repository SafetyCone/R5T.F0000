using System;


namespace R5T.F0000
{
	public class ExceptionMessageOperator : IExceptionMessageOperator
	{
		#region Infrastructure

	    public static IExceptionMessageOperator Instance { get; } = new ExceptionMessageOperator();

	    private ExceptionMessageOperator()
	    {
        }

	    #endregion
	}
}