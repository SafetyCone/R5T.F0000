using System;


namespace R5T.F0000
{
	public class Descriptions : IDescriptions
	{
		#region Infrastructure

	    public static Descriptions Instance { get; } = new();

	    private Descriptions()
	    {
        }

	    #endregion
	}
}