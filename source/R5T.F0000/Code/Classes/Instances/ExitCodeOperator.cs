using System;


namespace R5T.F0000
{
	public class ExitCodeOperator : IExitCodeOperator
	{
		#region Infrastructure

	    public static ExitCodeOperator Instance { get; } = new();

	    private ExitCodeOperator()
	    {
        }

	    #endregion
	}
}