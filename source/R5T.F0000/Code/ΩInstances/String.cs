using System;


namespace R5T.F0000
{
	public class String : IString
	{
		#region Infrastructure

	    public static IString Instance { get; } = new String();

	    private String()
	    {
        }

	    #endregion
	}
}