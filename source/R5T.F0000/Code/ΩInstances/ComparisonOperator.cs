using System;


namespace R5T.F0000
{
	public class ComparisonOperator : IComparisonOperator
	{
		#region Infrastructure

	    public static IComparisonOperator Instance { get; } = new ComparisonOperator();

	    private ComparisonOperator()
	    {
        }

	    #endregion
	}
}