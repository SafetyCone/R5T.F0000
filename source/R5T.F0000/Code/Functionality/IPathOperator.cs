using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IPathOperator : IFunctionalityMarker
	{
        public string GetDirectoryName_FromDirectoryPath(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            var directoryName = directoryInfo.Name;
            return directoryName;
        }

        /// <summary>
        /// Gets the combined path of a file.
        /// </summary>
        /// <param name="directoryPathPart">No check is performed for directory-indicating terminating directory separator.</param>
        /// <param name="relativeFilePathPart">No check is performed for the root-indicating initial directory separator.</param>
        /// <returns>The combined file path.</returns>
        /// <remarks>
        /// Uses a simple string concatentation.
        /// </remarks>
        public string GetFilePath(
            string directoryPathPart,
            string relativeFilePathPart)
        {
            var output = directoryPathPart + relativeFilePathPart;
            return output;
        }

        /// <summary>
        /// Gets the characters that cannot occur in file names on the system executing the function.
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="Path.GetInvalidFileNameChars"/>.
        /// </remarks>
        public char[] GetInvalidFileNameCharacters()
        {
            var output = Path.GetInvalidFileNameChars();
            return output;
        }

        /// <summary>
        /// Returns the result of <see cref="Path.GetInvalidPathChars"/>.
        /// </summary>
        public char[] GetInvalidPathCharacters()
        {
            var output = Path.GetInvalidPathChars();
            return output;
        }

        /// <summary>
        /// Gets the directory path of the directory containing a specified file.
        /// </summary>
        /// <returns>The non-directory indicated directory path of the file's parent directory.</returns>
        /// <remarks>
        /// Uses the <see cref="FileInfo"/> class.
        /// </remarks>
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