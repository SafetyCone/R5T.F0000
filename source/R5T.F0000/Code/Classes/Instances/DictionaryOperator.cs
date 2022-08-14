using System;


namespace R5T.F0000
{
	public class DictionaryOperator : IDictionaryOperator
	{
		#region Infrastructure

	    public static DictionaryOperator Instance { get; } = new();

	    private DictionaryOperator()
	    {
        }

	    #endregion
	}
}