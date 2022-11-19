using System;


namespace R5T.F0000
{
	public class QueryOperator : IQueryOperator
	{
		#region Infrastructure

	    public static IQueryOperator Instance { get; } = new QueryOperator();

	    private QueryOperator()
	    {
        }

	    #endregion
	}
}