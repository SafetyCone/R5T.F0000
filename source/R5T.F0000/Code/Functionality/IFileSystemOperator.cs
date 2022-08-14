using System;
using System.IO;

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

        public bool FileExists(string filePath)
        {
            var output = File.Exists(filePath);
            return output;
        }
    }
}