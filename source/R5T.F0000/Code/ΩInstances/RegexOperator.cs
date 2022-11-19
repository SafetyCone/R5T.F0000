using System;


namespace R5T.F0000
{
	public class RegexOperator : IRegexOperator
	{
		#region Infrastructure

	    public static IRegexOperator Instance { get; } = new RegexOperator();

	    private RegexOperator()
	    {
        }

	    #endregion
	}
}