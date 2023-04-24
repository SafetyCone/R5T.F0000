using System;


namespace R5T.F0000.Construction
{
	public class Durations : IDurations
	{
		#region Infrastructure

	    public static Durations Instance { get; } = new();

	    private Durations()
	    {
        }

	    #endregion
	}
}