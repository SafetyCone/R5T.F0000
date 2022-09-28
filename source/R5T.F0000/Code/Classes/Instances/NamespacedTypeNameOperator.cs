using System;


namespace R5T.F0000
{
	public class NamespacedTypeNameOperator : INamespacedTypeNameOperator
	{
		#region Infrastructure

	    public static INamespacedTypeNameOperator Instance { get; } = new NamespacedTypeNameOperator();

	    private NamespacedTypeNameOperator()
	    {
        }

	    #endregion
	}
}