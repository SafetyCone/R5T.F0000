using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Prior work: R5T.Magyar.
    /// </remarks>
	[FunctionalityMarker]
	public partial interface IFileSystemOperator : IFunctionalityMarker,
        L0053.IFileSystemOperator
	{
        /// <summary>
        /// Chooses <see cref="L0066.IFileSystemOperator.Create_Directory_OkIfAlreadyExists(string)"/> as the default.
        /// </summary>
        public void CreateDirectory(string directoryPath)
        {
            this.Create_Directory_OkIfAlreadyExists(directoryPath);
        }

        /// <summary>
        /// Throws an exception if the directory already exists.
        /// </summary>
        public void CreateDirectory_NonIdempotent(string directoryPath)
        {
            var directoryExists = this.Exists_Directory(directoryPath);
            if(directoryExists)
            {
                throw new Exception("Directory already existed.");
            }

            this.Create_Directory_OkIfAlreadyExists(directoryPath);
        }

        public IEnumerable<string> EnumerateAllChildDirectoryPaths(string directoryPath)
        {
            var output = this.EnumerateChildDirectoryPaths(
                directoryPath,
                Instances.SearchPatterns.All);

            return output;
        }

        public IEnumerable<string> EnumerateAllChildFilePaths(
            string directoryPath)
        {
            var output = this.EnumerateChildFilePaths(
                directoryPath,
                Instances.SearchPatterns.All);

            return output;
        }

        public IEnumerable<string> EnumerateChildDirectoryPaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateDirectories(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
            return output;
        }

        public IEnumerable<string> EnumerateChildFilePaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateFiles(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
            return output;
        }

        public IEnumerable<string> EnumerateChildFilePathsByRegex(
            string directoryPath,
            string regexPattern)
        {
            var output = Directory.EnumerateFiles(directoryPath, Instances.SearchPatterns.All, SearchOption.TopDirectoryOnly)
                .Where(x => Regex.IsMatch(x, regexPattern))
                ;

            return output;
        }

        public IEnumerable<string> EnumerateChildFilePathsByRegexOnFileName(
            string directoryPath,
            string regexPattern)
        {
            var output = Directory.EnumerateFiles(directoryPath, Instances.SearchPatterns.All, SearchOption.TopDirectoryOnly)
                .Where(x => Regex.IsMatch(new FileInfo(x).Name, regexPattern))
                ;

            return output;
        }

        [Obsolete("Use R5T.L0066.IFileSystemOperator.Enumerate_Files()}")]
        public IEnumerable<FileInfo> EnumerateFiles(
            string directoryPath,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => this.Enumerate_Files_FileInfoOutput(
                directoryPath,
                descendantDirectoryRecursionPredicate);

        public string[] FindChildFilesInDirectoryByFileExtension(
            string directoryPath,
            string fileExtension)
        {
            var searchPattern = Instances.SearchPatternGenerator.Files_WithExtension(fileExtension);

            var output = this.FindChildFilesInDirectory(directoryPath, searchPattern)
                .ToArray();

            return output;
        }

        public IEnumerable<string> FindChildFilesInDirectory(
            string directoryPath,
            string searchPattern)
        {
            var output = this.EnumerateChildFilePaths(directoryPath, searchPattern);
            return output;
        }

        public IEnumerable<string> FindChildFilesInDirectoryByRegexOnFileName(
            string directoryPath,
            string regexPattern)
        {
            var output = this.EnumerateChildFilePathsByRegexOnFileName(directoryPath, regexPattern);
            return output;
        }

        public IEnumerable<string> FindFilesInDirectoryOrParentDirectories(
            string directoryPath,
            string searchPattern)
        {
            var childFilePaths = this.FindChildFilesInDirectory(
                directoryPath,
                searchPattern);

            var directoryInfo = this.GetDirectoryInfo(directoryPath);

            var isRootDirectory = directoryInfo.IsRoot();

            var parentFilePaths = isRootDirectory
                ? Instances.EnumerableOperator.Empty<string>()
                : this.FindFilesInDirectoryOrParentDirectories(
                    Instances.DirectoryInfoOperator.GetParentDirectoryPath(directoryInfo),
                    searchPattern);

            var filePaths = childFilePaths.Concat(parentFilePaths);
            return filePaths;
        }

        public DirectoryInfo GetDirectoryInfo(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);
            return directoryInfo;
        }

        /// <summary>
        /// Finds the file in the directory (and all sub-directories) that was the last to be modified, and return its modified time.
        /// </summary>
        public DateTime GetLastModifiedTime_ForDirectory_Local(
            string directoryPath,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
        {
            var output = this.Enumerate_Files_FileInfoOutput(
                directoryPath,
                descendantDirectoryRecursionPredicate)
                .Order_ByWriteTime_Descending()
                .First()
                .LastWriteTime;

            return output;
        }

        public async Task ClearDirectory(
            string directoryPath)
        {
            FileSystemOperator.Instance.Delete_Directory_OkIfNotExists(
                directoryPath);

            // Wait for the file-system to process the deletion.
            await Task.Delay(100);

            FileSystemOperator.Instance.CreateDirectory_NonIdempotent(
                directoryPath);
        }

        public void ClearDirectory_Synchronous(
            string directoryPath)
        {
            FileSystemOperator.Instance.Delete_Directory_OkIfNotExists(
                directoryPath);

            // Wait for the file-system to process the deletion.
            Thread.Sleep(100);

            FileSystemOperator.Instance.CreateDirectory_NonIdempotent(
                directoryPath);
        }

        /// <summary>
        /// Cleans out (deletes, then creates) a directory path.
        /// </summary>
        public async Task InClearedDirectoryContext(
            string temporaryDirectoryPath,
            Func<string, Task> directoryPathAction)
        {
            await this.ClearDirectory(temporaryDirectoryPath);   

            await directoryPathAction(temporaryDirectoryPath);
        }

        public bool IsRootDirectory(string directoryPath)
        {
            var directoryInfo = this.GetDirectoryInfo(directoryPath);

            var isRootDirectory = Instances.DirectoryInfoOperator.IsRootDirectory(directoryInfo);
            return isRootDirectory;
        }

        public string ReadText(string textFilePath)
        {
            var text = File.ReadAllText(textFilePath);
            return text;
        }

        public string[] ReadText_Lines(string textFilePath)
        {
            var lines = File.ReadAllLines(textFilePath);
            return lines;
        }

        /// <summary>
        /// Tests whether a directory exists, and if it does, throws a <see cref="Exception"/>.
        /// </summary>
        public void Verify_DirectoryDoesNotExists(string filePath)
        {
            var fileExists = this.Exists_Directory(filePath);
            if (fileExists)
            {
                throw new Exception($"Directory exists:\n{filePath}");
            }
        }
    }
}