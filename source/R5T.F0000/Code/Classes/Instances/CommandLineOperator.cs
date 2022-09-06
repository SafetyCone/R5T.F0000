using System;


namespace R5T.F0000
{
	public class CommandLineOperator : ICommandLineOperator
	{
		#region Infrastructure

	    public static CommandLineOperator Instance { get; } = new();

	    private CommandLineOperator()
	    {
        }

	    #endregion
	}
}