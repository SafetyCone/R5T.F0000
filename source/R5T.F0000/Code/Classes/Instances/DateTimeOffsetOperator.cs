using System;


namespace R5T.F0000
{
	public class DateTimeOffsetOperator : IDateTimeOffsetOperator
	{
		#region Infrastructure

	    public static IDateTimeOffsetOperator Instance { get; } = new DateTimeOffsetOperator();

	    private DateTimeOffsetOperator()
	    {
        }

	    #endregion
	}
}