using System;


namespace R5T.F0000
{
	public class FileSystemOperator : IFileSystemOperator
	{
		#region Infrastructure

	    public static IFileSystemOperator Instance { get; } = new FileSystemOperator();

	    private FileSystemOperator()
	    {
        }

	    #endregion
	}
}