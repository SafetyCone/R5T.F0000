using System;


namespace R5T.F0000
{
	public class DateOperator : IDateOperator
	{
		#region Infrastructure

	    public static IDateOperator Instance { get; } = new DateOperator();

	    private DateOperator()
	    {
        }

	    #endregion
	}
}