using System;


namespace R5T.F0000.Construction
{
	public class TypeOperations : ITypeOperations
	{
		#region Infrastructure

	    public static ITypeOperations Instance { get; } = new TypeOperations();

	    private TypeOperations()
	    {
        }

	    #endregion
	}
}