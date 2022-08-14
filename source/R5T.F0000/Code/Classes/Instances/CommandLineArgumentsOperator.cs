using System;


namespace R5T.F0000
{
	public class CommandLineArgumentsOperator : ICommandLineArgumentsOperator
	{
		#region Infrastructure

	    public static CommandLineArgumentsOperator Instance { get; } = new();

	    private CommandLineArgumentsOperator()
	    {
        }

	    #endregion
	}
}