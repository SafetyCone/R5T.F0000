using System;


namespace R5T.F0000
{
	public class EnumerationOperator : IEnumerationOperator
	{
		#region Infrastructure

	    public static IEnumerationOperator Instance { get; } = new EnumerationOperator();

	    private EnumerationOperator()
	    {
        }

	    #endregion
	}
}