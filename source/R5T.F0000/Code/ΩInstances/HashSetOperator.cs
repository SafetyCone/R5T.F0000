using System;


namespace R5T.F0000
{
	public class HashSetOperator : IHashSetOperator
	{
		#region Infrastructure

	    public static IHashSetOperator Instance { get; } = new HashSetOperator();

	    private HashSetOperator()
	    {
        }

	    #endregion
	}
}