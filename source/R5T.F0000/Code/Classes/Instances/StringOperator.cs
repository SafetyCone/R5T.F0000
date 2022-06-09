using System;


namespace R5T.F0000
{
	public class StringOperator : IStringOperator
	{
    	#region Infrastructure

	    public static StringOperator Instance { get; } = new();

	    private StringOperator()
	    {
	    }

    	#endregion
	}
}