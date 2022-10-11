using System;


namespace R5T.F0000
{
	public class StreamWriterOperator : IStreamWriterOperator
	{
		#region Infrastructure

	    public static IStreamWriterOperator Instance { get; } = new StreamWriterOperator();

	    private StreamWriterOperator()
	    {
        }

	    #endregion
	}
}