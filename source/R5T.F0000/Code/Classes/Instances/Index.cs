using System;


namespace R5T.F0000
{
	public class Index : IIndex
	{
		#region Infrastructure

	    public static Index Instance { get; } = new();

	    private Index()
	    {
        }

	    #endregion
	}
}