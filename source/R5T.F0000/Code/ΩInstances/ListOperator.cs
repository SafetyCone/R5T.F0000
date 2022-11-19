using System;


namespace R5T.F0000
{
	public class ListOperator : IListOperator
	{
		#region Infrastructure

	    public static IListOperator Instance { get; } = new ListOperator();

	    private ListOperator()
	    {
        }

	    #endregion
	}
}