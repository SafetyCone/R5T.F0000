using System;


namespace R5T.F0000
{
	public class ExceptionOperator : IExceptionOperator
	{
		#region Infrastructure

	    public static ExceptionOperator Instance { get; } = new();

	    private ExceptionOperator()
	    {
        }

	    #endregion
	}
}