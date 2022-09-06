using System;


namespace R5T.F0000
{
	public class ExceptionMessageOperator : IExceptionMessageOperator
	{
		#region Infrastructure

	    public static ExceptionMessageOperator Instance { get; } = new();

	    private ExceptionMessageOperator()
	    {
        }

	    #endregion
	}
}