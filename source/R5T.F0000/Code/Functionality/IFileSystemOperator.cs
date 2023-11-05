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
        /// Chooses <see cref="L0053.N000.IFileSystemOperator.Create_Directory_OkIfAlreadyExists(string)"/> as the default.
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
            var directoryExists = this.DirectoryExists(directoryPath);
            if(directoryExists)
            {
                throw new Exception("Directory already existed.");
            }

            this.Create_Directory_OkIfAlreadyExists(directoryPath);
        }

        public bool DirectoryExists(string directoryPath)
        {
			var output = Directory.Exists(directoryPath);
			return output;
        }

        /// <summary>
        /// Non-idempotently deletes a directory.
        /// An exception is thrown if the directory does not exist.
        /// </summary>
        public void DeleteDirectory_NonIdempotent(string directoryPath)
        {
            if (!this.DirectoryExists(directoryPath))
            {
                throw new DirectoryNotFoundException(directoryPath);
            }

            this.DeleteDirectory_Robust(directoryPath);
        }

        public void DeleteDirectory_Idempotent(string directoryPath)
        {
            if (this.DirectoryExists(directoryPath))
            {
                this.DeleteDirectory_Robust(directoryPath);
            }
        }

        public void DeleteDirectory_OkIfNotExists(string directoryPath)
        {
            this.DeleteDirectory_Idempotent(directoryPath);
        }

        public void DeleteFile_OkIfNotExists(string filePath)
        {
            var directoryForFileDirectoryPath = PathOperator.Instance.GetFileParentDirectoryPath(filePath);

            var directoryExists = this.DirectoryExists(directoryForFileDirectoryPath);
            if (!directoryExists)
            {
                // No need to delete file if directory containing it does not exist!
                return;
            }

            File.Delete(filePath);
        }

        /// <summary>
        /// Deletes a directory path.
        /// The <see cref="System.IO.Directory.Delete(string)"/> method throws a <see cref="System.IO.DirectoryNotFoundException"/> if attempting to delete a non-existent directory. This is annoying.
        /// All you really want is the directory to not exist, so this method simply takes care of checking if the directory exists.
        /// Also annoying, you need to specify the recursive option to delete a directory with anything in it. This method also takes care of specifying true for the recursive option.
        /// Even more annoying, even after specifying the recursive option, the system method will not delete read-only files. Thus this method disables read-only options on all files recursively.
        /// </summary>
        public void DeleteDirectory_Robust(string directoryPath)
        {
            if (this.DirectoryExists(directoryPath))
            {
                this.DisableReadOnly(directoryPath);

                this.DeleteDirectory_NonRobust(directoryPath);
            }
        }

        public void DeleteDirectory_NonRobust(string directoryPath)
        {
            Directory.Delete(directoryPath, true);
        }

        public void DisableReadOnly(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            this.DisableReadOnly(directoryInfo);
        }

        /// <summary>
        /// Remove the read-only attribute from all files.
        /// </summary>
        /// <remarks>
        /// Adapted from: https://stackoverflow.com/questions/1982209/cannot-programatically-delete-svn-working-copy
        /// </remarks>
        public void DisableReadOnly(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.IsReadOnly)
                {
                    file.IsReadOnly = false;
                }
            }

            foreach (var subdirectory in directoryInfo.GetDirectories())
            {
                this.DisableReadOnly(subdirectory);
            }
        }

        public void EnsureDirectoryExists(string directoryPath)
        {
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

        public IEnumerable<FileInfo> EnumerateFiles(
            string directoryPath,
            Func<DirectoryInfo, bool> subDirectoryRecursionPredicate)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                yield return fileInfo;
            }

            foreach (var subDirectoryInfo in directoryInfo.GetDirectories())
            {
                var recurseInfoSubDirectory = subDirectoryRecursionPredicate(subDirectoryInfo);
                if (recurseInfoSubDirectory)
                {
                    var subDirectoryPath = subDirectoryInfo.GetDirectoryPath();

                    var subFiles = this.EnumerateFiles(
                        subDirectoryPath,
                        subDirectoryRecursionPredicate);

                    foreach (var subFile in subFiles)
                    {
                        yield return subFile;
                    }
                }
            }
        }

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
            Func<DirectoryInfo, bool> subDirectoryRecursionPredicate)
        {
            var output = this.EnumerateFiles(
                directoryPath,
                subDirectoryRecursionPredicate)
                .OrderByDescending(x => x.LastWriteTimeUtc)
                .First()
                .LastWriteTime;

            return output;
        }

        public async Task ClearDirectory(
            string directoryPath)
        {
            FileSystemOperator.Instance.DeleteDirectory_OkIfNotExists(
                directoryPath);

            // Wait for the file-system to process the deletion.
            await Task.Delay(100);

            FileSystemOperator.Instance.CreateDirectory_NonIdempotent(
                directoryPath);
        }

        public void ClearDirectory_Synchronous(
            string directoryPath)
        {
            FileSystemOperator.Instance.DeleteDirectory_OkIfNotExists(
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
        /// Tests whether a file exists, and if it doesn't, throws a <see cref="FileNotFoundException"/>.
        /// </summary>
        public void VerifyFileExists(string filePath)
        {
            var fileExists = this.Exists_File(filePath);
            if(!fileExists)
            {
                throw new FileNotFoundException("File did not exists.", filePath);
            }
        }

        /// <summary>
        /// Tests whether a file exists, and if it does, throws an <see cref="Exception"/>.
        /// </summary>
        public void VerifyFileDoesNotExists(string filePath)
        {
            var fileExists = this.Exists_File(filePath);
            if (fileExists)
            {
                throw new Exception($"File exists:\n{filePath}");
            }
        }

        /// <summary>
        /// Tests whether a directory exists, and if it does, throws a <see cref="Exception"/>.
        /// </summary>
        public void Verify_DirectoryDoesNotExists(string filePath)
        {
            var fileExists = this.DirectoryExists(filePath);
            if (fileExists)
            {
                throw new Exception($"Directory exists:\n{filePath}");
            }
        }
    }
}