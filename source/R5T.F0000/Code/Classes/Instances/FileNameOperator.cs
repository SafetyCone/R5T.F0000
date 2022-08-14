using System;


namespace R5T.F0000
{
	public class FileNameOperator : IFileNameOperator
	{
		#region Infrastructure

	    public static FileNameOperator Instance { get; } = new();

	    private FileNameOperator()
	    {
        }

	    #endregion
	}
}