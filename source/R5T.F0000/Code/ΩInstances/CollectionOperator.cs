using System;


namespace R5T.F0000
{
	public class CollectionOperator : ICollectionOperator
	{
		#region Infrastructure

	    public static ICollectionOperator Instance { get; } = new CollectionOperator();

	    private CollectionOperator()
	    {
        }

	    #endregion
	}
}