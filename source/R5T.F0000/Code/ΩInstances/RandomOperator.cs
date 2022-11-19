using System;


namespace R5T.F0000
{
	public class RandomOperator : IRandomOperator
	{
		#region Infrastructure

	    public static IRandomOperator Instance { get; } = new RandomOperator();

	    private RandomOperator()
	    {
        }

	    #endregion
	}
}