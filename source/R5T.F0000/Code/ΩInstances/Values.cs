using System;


namespace R5T.F0000
{
	public class Values : IValues
	{
		#region Infrastructure

	    public static IValues Instance { get; } = new Values();

	    private Values()
	    {
        }

	    #endregion
	}
}