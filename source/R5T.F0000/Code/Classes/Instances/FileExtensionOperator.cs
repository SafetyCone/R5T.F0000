using System;


namespace R5T.F0000
{
	public class FileExtensionOperator : IFileExtensionOperator
	{
		#region Infrastructure

	    public static FileExtensionOperator Instance { get; } = new();

	    private FileExtensionOperator()
	    {
        }

	    #endregion
	}
}