using System;


namespace R5T.F0000
{
	public class Descriptions : IDescriptions
	{
		#region Infrastructure

	    public static IDescriptions Instance { get; } = new Descriptions();

	    private Descriptions()
	    {
        }

	    #endregion
	}
}