using System;


namespace R5T.F0000
{
	public class TextOperator : ITextOperator
	{
		#region Infrastructure

	    public static TextOperator Instance { get; } = new();

	    private TextOperator()
	    {
        }

	    #endregion
	}
}