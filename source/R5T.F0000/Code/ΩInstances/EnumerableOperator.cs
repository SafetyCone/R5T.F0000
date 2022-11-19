using System;


namespace R5T.F0000
{
	public class EnumerableOperator : IEnumerableOperator
	{
		#region Infrastructure

	    public static IEnumerableOperator Instance { get; } = new EnumerableOperator();

	    private EnumerableOperator()
	    {
        }

	    #endregion
	}
}