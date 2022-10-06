using System;


namespace R5T.F0000
{
	public class FileStreamOperator : IFileStreamOperator
	{
		#region Infrastructure

	    public static IFileStreamOperator Instance { get; } = new FileStreamOperator();

	    private FileStreamOperator()
	    {
        }

	    #endregion
	}
}