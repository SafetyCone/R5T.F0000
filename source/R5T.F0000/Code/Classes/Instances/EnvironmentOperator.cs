using System;


namespace R5T.F0000
{
	public class EnvironmentOperator : IEnvironmentOperator
	{
		#region Infrastructure

	    public static EnvironmentOperator Instance { get; } = new();

	    private EnvironmentOperator()
	    {
        }

	    #endregion
	}
}