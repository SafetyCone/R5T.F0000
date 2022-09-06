using System;


namespace R5T.F0000
{
	public class ExitCodes : IExitCodes
	{
		#region Infrastructure

	    public static ExitCodes Instance { get; } = new();

	    private ExitCodes()
	    {
        }

	    #endregion
	}
}