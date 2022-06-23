using System;


namespace R5T.F0000.Construction
{
	public class GuidFormatDemonstration : IGuidFormatDemonstration
	{
		#region Infrastructure

	    public static GuidFormatDemonstration Instance { get; } = new();

	    private GuidFormatDemonstration()
	    {
        }

	    #endregion
	}
}