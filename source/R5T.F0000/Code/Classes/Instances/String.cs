using System;


namespace R5T.F0000
{
	public class String : IString
	{
		#region Infrastructure

	    public static String Instance { get; } = new();

	    private String()
	    {
        }

	    #endregion
	}
}