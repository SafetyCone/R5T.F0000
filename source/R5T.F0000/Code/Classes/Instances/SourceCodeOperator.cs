using System;


namespace R5T.F0000
{
	public class SourceCodeOperator : ISourceCodeOperator
	{
		#region Infrastructure

	    public static ISourceCodeOperator Instance { get; } = new SourceCodeOperator();

	    private SourceCodeOperator()
	    {
        }

	    #endregion
	}
}