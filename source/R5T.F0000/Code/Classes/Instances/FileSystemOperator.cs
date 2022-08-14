using System;


namespace R5T.F0000
{
	public class FileSystemOperator : IFileSystemOperator
	{
		#region Infrastructure

	    public static FileSystemOperator Instance { get; } = new();

	    private FileSystemOperator()
	    {
        }

	    #endregion
	}
}