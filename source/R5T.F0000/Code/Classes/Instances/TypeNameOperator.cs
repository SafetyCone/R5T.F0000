using System;


namespace R5T.F0000
{
	public class TypeNameOperator : ITypeNameOperator
	{
		#region Infrastructure

	    public static TypeNameOperator Instance { get; } = new();

	    private TypeNameOperator()
	    {
        }

	    #endregion
	}
}