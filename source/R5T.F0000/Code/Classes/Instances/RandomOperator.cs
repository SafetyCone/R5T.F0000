using System;


namespace R5T.F0000
{
	public class RandomOperator : IRandomOperator
	{
		#region Infrastructure

	    public static RandomOperator Instance { get; } = new();

	    private RandomOperator()
	    {
        }

	    #endregion
	}
}