using System;


namespace R5T.F0000
{
	public class FileOperator : IFileOperator
	{
		#region Infrastructure

	    public static FileOperator Instance { get; } = new();

	    private FileOperator()
	    {
        }

	    #endregion
	}
}