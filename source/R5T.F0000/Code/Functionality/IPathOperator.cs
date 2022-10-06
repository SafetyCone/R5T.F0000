using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IPathOperator : IFunctionalityMarker
	{
        public string GetParentDirectoryPath(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            var parentDirectoryPath = fileInfo.Directory.FullName;
            return parentDirectoryPath;
        }
    }
}