using System;


namespace R5T.F0000
{
	public class ArrayOperator : IArrayOperator
	{
		#region Infrastructure

	    public static ArrayOperator Instance { get; } = new();

	    private ArrayOperator()
	    {
        }

	    #endregion
	}
}