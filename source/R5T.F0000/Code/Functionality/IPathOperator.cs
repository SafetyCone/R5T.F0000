using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IPathOperator : IFunctionalityMarker
	{
        public string GetFileParentDirectoryPath(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            var parentDirectoryPath = fileInfo.Directory.FullName;
            return parentDirectoryPath;
        }

        public bool HasFileExtension(
            string filePath,
            string fileExtension)
        {
            var hasFileExtension = Instances.StringOperator.EndsWith(
                filePath,
                fileExtension);

            return hasFileExtension;
        }
    }
}