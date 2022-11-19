using System;


namespace R5T.F0000
{
	public class ConsoleOperator : IConsoleOperator
	{
		#region Infrastructure

	    public static IConsoleOperator Instance { get; } = new ConsoleOperator();

	    private ConsoleOperator()
	    {
        }

	    #endregion
	}
}