using System;


namespace R5T.F0000.Construction
{
	public class DotnetCommandLineOperator : IDotnetCommandLineOperator
	{
		#region Infrastructure

	    public static DotnetCommandLineOperator Instance { get; } = new();

	    private DotnetCommandLineOperator()
	    {
        }

	    #endregion
	}
}