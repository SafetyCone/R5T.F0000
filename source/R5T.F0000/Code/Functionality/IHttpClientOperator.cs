using System;

using R5T.T0132;


namespace R5T.F0000
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Useful information:
	/// * https://josef.codes/you-are-probably-still-using-httpclient-wrong-and-it-is-destabilizing-your-software/
	/// * https://www.rahulpnath.com/blog/are-you-using-httpclient-in-the-right-way/
	/// * https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines
	/// * https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#benefits-of-using-ihttpclientfactory?WT.mc_id=AZ-MVP-5003875
	/// 
	/// </remarks>
	[FunctionalityMarker]
	public partial interface IHttpClientOperator : IFunctionalityMarker
	{
	}
}