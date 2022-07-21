using System;


namespace R5T.F0000
{
	public class EnumerableOperator : IEnumerableOperator
	{
		#region Infrastructure

	    public static EnumerableOperator Instance { get; } = new();

	    private EnumerableOperator()
	    {
        }

	    #endregion
	}
}