using System;


namespace R5T.F0000
{
	public class SourceCodeOperator : ISourceCodeOperator
	{
		#region Infrastructure

	    public static SourceCodeOperator Instance { get; } = new();

	    private SourceCodeOperator()
	    {
        }

	    #endregion
	}
}