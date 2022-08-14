using System;


namespace R5T.F0000
{
	public class Seeds : ISeeds
	{
		#region Infrastructure

	    public static Seeds Instance { get; } = new();

	    private Seeds()
	    {
        }

	    #endregion
	}
}