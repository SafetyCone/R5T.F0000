using System;


namespace R5T.F0000
{
	public class NowOperator : INowOperator
	{
		#region Infrastructure

	    public static NowOperator Instance { get; } = new();

	    private NowOperator()
	    {
        }

	    #endregion
	}
}