using System;


namespace R5T.F0000
{
	public class ComparisonResults : IComparisonResults
	{
		#region Infrastructure

	    public static IComparisonResults Instance { get; } = new ComparisonResults();

	    private ComparisonResults()
	    {
        }

	    #endregion
	}
}