using System;


namespace R5T.F0000
{
	public class ExceptionMessages : IExceptionMessages
	{
		#region Infrastructure

	    public static IExceptionMessages Instance { get; } = new ExceptionMessages();

	    private ExceptionMessages()
	    {
        }

	    #endregion
	}
}