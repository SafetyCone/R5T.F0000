using System;


namespace R5T.F0000
{
	public class NowOperator : INowOperator
	{
		#region Infrastructure

	    public static INowOperator Instance { get; } = new NowOperator();

	    private NowOperator()
	    {
        }

	    #endregion
	}
}