using System;


namespace R5T.F0000
{
	public class SearchPatterns : ISearchPatterns
	{
		#region Infrastructure

	    public static SearchPatterns Instance { get; } = new();

	    private SearchPatterns()
	    {
        }

	    #endregion
	}
}