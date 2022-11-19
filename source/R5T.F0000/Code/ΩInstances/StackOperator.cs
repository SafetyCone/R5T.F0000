using System;


namespace R5T.F0000
{
	public class StackOperator : IStackOperator
	{
		#region Infrastructure

	    public static IStackOperator Instance { get; } = new StackOperator();

	    private StackOperator()
	    {
        }

	    #endregion
	}
}