using System;


namespace R5T.F0000
{
	public class FileExtensionOperator : IFileExtensionOperator
	{
		#region Infrastructure

	    public static IFileExtensionOperator Instance { get; } = new FileExtensionOperator();

	    private FileExtensionOperator()
	    {
        }

	    #endregion
	}
}