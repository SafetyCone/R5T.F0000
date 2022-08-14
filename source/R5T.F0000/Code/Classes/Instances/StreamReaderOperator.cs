using System;


namespace R5T.F0002
{
	public class StreamReaderOperator : IStreamReaderOperator
	{
		#region Infrastructure

	    public static StreamReaderOperator Instance { get; } = new();

	    private StreamReaderOperator()
	    {
        }

	    #endregion
	}
}