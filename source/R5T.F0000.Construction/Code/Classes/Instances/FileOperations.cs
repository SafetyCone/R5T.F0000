using System;


namespace R5T.F0000.Construction
{
	public class FileOperations : IFileOperations
	{
		#region Infrastructure

	    public static IFileOperations Instance { get; } = new FileOperations();

	    private FileOperations()
	    {
        }

	    #endregion
	}
}