using System;


namespace R5T.F0000
{
	public class HttpClientOperator : IHttpClientOperator
	{
		#region Infrastructure

	    public static IHttpClientOperator Instance { get; } = new HttpClientOperator();

	    private HttpClientOperator()
	    {
        }

	    #endregion
	}
}