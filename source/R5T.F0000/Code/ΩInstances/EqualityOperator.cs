using System;


namespace R5T.F0000
{
	public class EqualityOperator : IEqualityOperator
	{
		#region Infrastructure

	    public static IEqualityOperator Instance { get; } = new EqualityOperator();

	    private EqualityOperator()
	    {
        }

	    #endregion
	}
}