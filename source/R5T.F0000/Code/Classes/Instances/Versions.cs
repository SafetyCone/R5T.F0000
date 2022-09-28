using System;


namespace R5T.F0000
{
	public class Versions : IVersions
	{
		#region Infrastructure

	    public static IVersions Instance { get; } = new Versions();

	    private Versions()
	    {
        }

	    #endregion
	}
}