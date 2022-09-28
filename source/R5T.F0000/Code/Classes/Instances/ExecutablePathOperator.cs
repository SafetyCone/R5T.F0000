using System;


namespace R5T.F0000
{
	public class ExecutablePathOperator : IExecutablePathOperator
	{
		#region Infrastructure

	    public static IExecutablePathOperator Instance { get; } = new ExecutablePathOperator();

	    private ExecutablePathOperator()
	    {
        }

	    #endregion
	}
}