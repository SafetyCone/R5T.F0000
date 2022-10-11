using System;


namespace R5T.F0000
{
	public class StreamReaderValues : IStreamReaderValues
	{
		#region Infrastructure

	    public static IStreamReaderValues Instance { get; } = new StreamReaderValues();

	    private StreamReaderValues()
	    {
        }

	    #endregion
	}
}