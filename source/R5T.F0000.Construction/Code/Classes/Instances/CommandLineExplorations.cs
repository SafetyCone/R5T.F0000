using System;


namespace R5T.F0000.Construction
{
	public class CommandLineExplorations : ICommandLineExplorations
	{
		#region Infrastructure

	    public static CommandLineExplorations Instance { get; } = new();

	    private CommandLineExplorations()
	    {
        }

	    #endregion
	}
}