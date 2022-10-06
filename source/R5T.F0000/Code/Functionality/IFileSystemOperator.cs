using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
	public partial interface IFileSystemOperator : IFunctionalityMarker
	{
        public async Task ClearFile(string filePath)
        {
            await File.WriteAllTextAsync(
                filePath,
                System.String.Empty);
        }

        public void ClearFile_Synchronous(string filePath)
        {
            File.WriteAllText(
                filePath,
                System.String.Empty);
        }

        /// <summary>
        /// Copies a directory.
        /// </summary>
        /// <remarks>
        /// It is BONKERS that C# does not have a built-in implementation of copying directories. Wut?!?
        /// </remarks>
        public void CopyDirectory(
            string sourceDirectoryPath,
            string destinationDirectoryPath,
            bool recursive = true)
        {
            /// Adapted from: https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories

            // Get information about the source directory
            var directory = new DirectoryInfo(sourceDirectoryPath);

            // Check if the source directory exists
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {directory.FullName}");
            }

            // Cache directories before we start copying.
            DirectoryInfo[] subDirectories = directory.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDirectoryPath);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in directory.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDirectoryPath, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    string newDestinationDirectoryPath = Path.Combine(destinationDirectoryPath, subDirectory.Name);

                    this.CopyDirectory(subDirectory.FullName, newDestinationDirectoryPath, true);
                }
            }
        }

        public void CopyFiles(IEnumerable<FileCopyPair> fileCopyPairs)
        {
            foreach (var fileCopyPair in fileCopyPairs)
            {
                this.CopyFile(fileCopyPair);
            }
        }

        public void CopyFile(FileCopyPair fileCopyPair)
        {
            this.CopyFile(
                fileCopyPair.SourceFilePath,
                fileCopyPair.DestinationFilePath);
        }

        public void CopyFile(
			string sourceFilePath,
			string destinationFilePath)
        {
			File.Copy(
				sourceFilePath,
				destinationFilePath,
				true);
        }

        public void CreateDirectory(string directoryPath)
        {
            this.CreateDirectory_OkIfAlreadyExists(directoryPath);
        }

        /// <summary>
        /// Creates a directory idempotently (meaning there is no problem with issuing the command multiple times). 
        /// Note: The system method <see cref="Directory.CreateDirectory(string)"/> does not throw an exception if you create a directory that already exists. However, it's hard to remember this fact. Thus, this method name makes that fact explicit.
        /// </summary>
        public void CreateDirectory_OkIfAlreadyExists(string directoryPath)
        {
            // Does not throw an exception if a directory already exists.
            // See proof at: https://github.com/MinexAutomation/Public/blob/a8c302415b56fb8903c751436cbeef3eae8e1692/Source/Experiments/CSharp/ExaminingCSharp/ExaminingCSharp/Code/Experiments/IOExperiments.cs#L24
            Directory.CreateDirectory(directoryPath);
        }

        public bool DirectoryExists(string directoryPath)
        {
			var output = Directory.Exists(directoryPath);
			return output;
        }

        public void DeleteDirectory_OkIfNotExists(string directoryPath)
        {
            if (this.DirectoryExists(directoryPath))
            {
                this.DeleteDirectory_Robust(directoryPath);
            }
        }

        public void DeleteFile_OkIfNotExists(string filePath)
        {
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

        public void EnsureDirectoryForFilePathExists(string filePath)
        {
            var directoryPath = PathOperator.Instance.GetParentDirectoryPath(filePath);

            Instances.FileSystemOperator.CreateDirectory_OkIfAlreadyExists(directoryPath);
        }

        public void EnsureDirectoryExists(string directoryPath)
        {
            this.CreateDirectory_OkIfAlreadyExists(directoryPath);
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

        public bool FileExists(string filePath)
        {
            var output = File.Exists(filePath);
            return output;
        }

        public string[] FindChildFilesInDirectoryByFileExtension(
            string directoryPath,
            string fileExtension)
        {
            var searchPattern = Instances.SearchPatternGenerator.AllFilesWithExtension(fileExtension);

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

        public void VerifyFileExists(string filePath)
        {
            var fileExists = this.FileExists(filePath);
            if(!fileExists)
            {
                throw new FileNotFoundException("File did not exists.", filePath);
            }
        }
    }
}