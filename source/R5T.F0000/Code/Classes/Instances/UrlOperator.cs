using System;


namespace R5T.F0000
{
	public class UrlOperator : IUrlOperator
	{
		#region Infrastructure

	    public static UrlOperator Instance { get; } = new();

	    private UrlOperator()
	    {
        }

	    #endregion
	}
}