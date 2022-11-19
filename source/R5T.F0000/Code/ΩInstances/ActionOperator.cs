using System;


namespace R5T.F0000
{
	public class ActionOperator : IActionOperator
	{
		#region Infrastructure

	    public static IActionOperator Instance { get; } = new ActionOperator();

	    private ActionOperator()
	    {
        }

	    #endregion
	}
}