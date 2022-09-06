using System;


namespace R5T.F0000
{
	public class Messages : IMessages
	{
		#region Infrastructure

	    public static Messages Instance { get; } = new();

	    private Messages()
	    {
        }

	    #endregion
	}
}