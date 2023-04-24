using System;


namespace R5T.F0000.Construction
{
	public class ExecutableFilePaths : IExecutableFilePaths
	{
		#region Infrastructure

	    public static ExecutableFilePaths Instance { get; } = new();

	    private ExecutableFilePaths()
	    {
        }

	    #endregion
	}
}