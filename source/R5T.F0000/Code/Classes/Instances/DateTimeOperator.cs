using System;


namespace R5T.F0000
{
	public class DateTimeOperator : IDateTimeOperator
	{
		#region Infrastructure

	    public static DateTimeOperator Instance { get; } = new();

	    private DateTimeOperator()
	    {
        }

	    #endregion
	}
}