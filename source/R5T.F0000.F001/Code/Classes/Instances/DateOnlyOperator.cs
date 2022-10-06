using System;


namespace R5T.F0000.F001
{
	public class DateOnlyOperator : IDateOnlyOperator
	{
		#region Infrastructure

	    public static IDateOnlyOperator Instance { get; } = new DateOnlyOperator();

	    private DateOnlyOperator()
	    {
        }

	    #endregion
	}
}