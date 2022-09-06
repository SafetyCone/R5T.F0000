using System;


namespace R5T.F0000
{
	public class SearchPatternOperator : ISearchPatternOperator
	{
		#region Infrastructure

	    public static SearchPatternOperator Instance { get; } = new();

	    private SearchPatternOperator()
	    {
        }

	    #endregion
	}
}