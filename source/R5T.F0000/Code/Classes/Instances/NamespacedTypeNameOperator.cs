using System;


namespace R5T.F0000
{
	public class NamespacedTypeNameOperator : INamespacedTypeNameOperator
	{
		#region Infrastructure

	    public static NamespacedTypeNameOperator Instance { get; } = new();

	    private NamespacedTypeNameOperator()
	    {
        }

	    #endregion
	}
}