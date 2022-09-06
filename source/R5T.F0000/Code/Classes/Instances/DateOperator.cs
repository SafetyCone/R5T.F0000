using System;


namespace R5T.F0000
{
	public class DateOperator : IDateOperator
	{
		#region Infrastructure

	    public static DateOperator Instance { get; } = new();

	    private DateOperator()
	    {
        }

	    #endregion
	}
}