using System;


namespace R5T.F0000
{
	public class DateTimeFormats : IDateTimeFormats
	{
		#region Infrastructure

	    public static IDateTimeFormats Instance { get; } = new DateTimeFormats();

	    private DateTimeFormats()
	    {
        }

	    #endregion
	}
}