using System;


namespace R5T.F0000
{
	public class ListOperator : IListOperator
	{
		#region Infrastructure

	    public static ListOperator Instance { get; } = new();

	    private ListOperator()
	    {
        }

	    #endregion
	}
}