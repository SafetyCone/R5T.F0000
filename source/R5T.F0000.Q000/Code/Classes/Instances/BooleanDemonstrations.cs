using System;


namespace R5T.F0000.Q000
{
	public class BooleanDemonstrations : IBooleanDemonstrations
	{
		#region Infrastructure

	    public static BooleanDemonstrations Instance { get; } = new();

	    private BooleanDemonstrations()
	    {
        }

	    #endregion
	}
}