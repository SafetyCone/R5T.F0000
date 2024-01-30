using System;
using System.Net;

using R5T.L0089.T000;
using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IIPAddressOperator : IFunctionalityMarker
	{
		public WasFound<IPAddress> IsIPAddress(string possibleIPAddress)
        {
			var isAddress = IPAddress.TryParse(possibleIPAddress, out var address);

			return WasFound.From(isAddress, address);
        }
	}
}