using System;


namespace R5T.F0000
{
	public class SyncOverAsyncOperator : ISyncOverAsyncOperator
	{
		#region Infrastructure

	    public static ISyncOverAsyncOperator Instance { get; } = new SyncOverAsyncOperator();

	    private SyncOverAsyncOperator()
	    {
        }

	    #endregion
	}
}