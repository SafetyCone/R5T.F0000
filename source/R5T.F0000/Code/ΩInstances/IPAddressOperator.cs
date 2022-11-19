using System;


namespace R5T.F0000
{
	public class IPAddressOperator : IIPAddressOperator
	{
		#region Infrastructure

	    public static IIPAddressOperator Instance { get; } = new IPAddressOperator();

	    private IPAddressOperator()
	    {
        }

	    #endregion
	}
}