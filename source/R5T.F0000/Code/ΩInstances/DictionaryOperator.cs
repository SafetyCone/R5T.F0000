using System;


namespace R5T.F0000
{
	public class DictionaryOperator : IDictionaryOperator
	{
		#region Infrastructure

	    public static IDictionaryOperator Instance { get; } = new DictionaryOperator();

	    private DictionaryOperator()
	    {
        }

	    #endregion
	}
}