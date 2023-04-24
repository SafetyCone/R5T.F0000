using System;


namespace R5T.F0000.Construction
{
	public class CommandLineOperations : ICommandLineOperations
	{
		#region Infrastructure

	    public static CommandLineOperations Instance { get; } = new();

	    private CommandLineOperations()
	    {
        }

	    #endregion
	}
}