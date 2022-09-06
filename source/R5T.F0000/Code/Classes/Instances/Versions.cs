using System;


namespace R5T.F0000
{
	public class Versions : IVersions
	{
		#region Infrastructure

	    public static Versions Instance { get; } = new();

	    private Versions()
	    {
        }

	    #endregion
	}
}