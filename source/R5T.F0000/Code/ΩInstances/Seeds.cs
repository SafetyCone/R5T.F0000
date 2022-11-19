using System;


namespace R5T.F0000
{
	public class Seeds : ISeeds
	{
		#region Infrastructure

	    public static ISeeds Instance { get; } = new Seeds();

	    private Seeds()
	    {
        }

	    #endregion
	}
}