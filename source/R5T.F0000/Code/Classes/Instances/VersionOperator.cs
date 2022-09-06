using System;


namespace R5T.F0000
{
	public class VersionOperator : IVersionOperator
	{
		#region Infrastructure

	    public static VersionOperator Instance { get; } = new();

	    private VersionOperator()
	    {
        }

	    #endregion
	}
}