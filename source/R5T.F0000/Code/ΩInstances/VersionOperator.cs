using System;


namespace R5T.F0000
{
	public class VersionOperator : IVersionOperator
	{
		#region Infrastructure

	    public static IVersionOperator Instance { get; } = new VersionOperator();

	    private VersionOperator()
	    {
        }

	    #endregion
	}
}