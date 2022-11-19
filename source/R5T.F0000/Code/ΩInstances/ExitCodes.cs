using System;


namespace R5T.F0000
{
	public class ExitCodes : IExitCodes
	{
		#region Infrastructure

	    public static IExitCodes Instance { get; } = new ExitCodes();

	    private ExitCodes()
	    {
        }

	    #endregion
	}
}