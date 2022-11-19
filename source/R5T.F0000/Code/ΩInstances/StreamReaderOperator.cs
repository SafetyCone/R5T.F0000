using System;


namespace R5T.F0000
{
	public class StreamReaderOperator : IStreamReaderOperator
	{
		#region Infrastructure

	    public static IStreamReaderOperator Instance { get; } = new StreamReaderOperator();

	    private StreamReaderOperator()
	    {
        }

	    #endregion
	}
}