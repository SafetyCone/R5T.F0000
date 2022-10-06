using System;


namespace R5T.F0000.F001
{
	public class TimeOnlyOperator : ITimeOnlyOperator
	{
		#region Infrastructure

	    public static ITimeOnlyOperator Instance { get; } = new TimeOnlyOperator();

	    private TimeOnlyOperator()
	    {
        }

	    #endregion
	}
}