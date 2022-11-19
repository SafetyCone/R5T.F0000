using System;


namespace R5T.F0000
{
	public class Index : IIndex
	{
		#region Infrastructure

	    public static IIndex Instance { get; } = new Index();

	    private Index()
	    {
        }

	    #endregion
	}
}