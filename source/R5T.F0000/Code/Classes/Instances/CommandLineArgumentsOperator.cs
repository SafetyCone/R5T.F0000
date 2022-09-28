using System;


namespace R5T.F0000
{
	public class CommandLineArgumentsOperator : ICommandLineArgumentsOperator
	{
		#region Infrastructure

	    public static ICommandLineArgumentsOperator Instance { get; } = new CommandLineArgumentsOperator();

	    private CommandLineArgumentsOperator()
	    {
        }

	    #endregion
	}
}