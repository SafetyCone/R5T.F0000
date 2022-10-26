using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IDirectoryInfoOperator : IFunctionalityMarker
	{
        public string GetDirectoryPath(DirectoryInfo directoryInfo)
        {
            var directoryPath = directoryInfo.FullName;
            return directoryPath;
        }

        public DirectoryInfo GetParentDirectoryInfo(DirectoryInfo directoryInfo)
        {
            var parentDirectoryInfo = directoryInfo.Parent;
            return parentDirectoryInfo;
        }

        public string GetParentDirectoryPath(DirectoryInfo directoryInfo)
        {
            var parentDirectoryInfo = this.GetParentDirectoryInfo(directoryInfo);

            var parentDirectoryPath = this.GetDirectoryPath(parentDirectoryInfo);
            return parentDirectoryPath;
        }

        public bool IsRootDirectory(DirectoryInfo directoryInfo)
        {
            var isRootDirectory = directoryInfo.Parent is null;
            return isRootDirectory;
        }
    }
}