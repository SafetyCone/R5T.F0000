using System;


namespace R5T.F0000
{
	public class TypeOperator : ITypeOperator
	{
		#region Infrastructure

	    public static TypeOperator Instance { get; } = new();

	    private TypeOperator()
	    {
        }

	    #endregion
	}
}