using System;


namespace R5T.F0000
{
	public class WasFoundOperator : IWasFoundOperator
	{
		#region Infrastructure

	    public static IWasFoundOperator Instance { get; } = new WasFoundOperator();

	    private WasFoundOperator()
	    {
        }

	    #endregion
	}
}