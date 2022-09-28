using System;


namespace R5T.F0000
{
	public class WebOperator : IWebOperator
	{
		#region Infrastructure

	    public static IWebOperator Instance { get; } = new WebOperator();

	    private WebOperator()
	    {
        }

	    #endregion
	}
}