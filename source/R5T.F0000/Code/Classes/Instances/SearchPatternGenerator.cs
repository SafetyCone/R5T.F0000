using System;


namespace R5T.F0000
{
	public class SearchPatternGenerator : ISearchPatternGenerator
	{
		#region Infrastructure

	    public static SearchPatternGenerator Instance { get; } = new();

	    private SearchPatternGenerator()
	    {
        }

	    #endregion
	}
}