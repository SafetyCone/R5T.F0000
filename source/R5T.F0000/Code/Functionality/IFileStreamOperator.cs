using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileStreamOperator : IFunctionalityMarker
	{
        /// <summary>
        /// Eases construction of a new <see cref="FileStream"/> with a best-practice implementation of handling the overwrite parameter.
        /// </summary>
        public FileStream NewWrite(
            string filePath,
            bool overwrite = IValues.DefaultOverwriteValue_Const)
        {
            FileSystemOperator.Instance.EnsureDirectoryForFilePathExists(filePath);

            FileMode fileMode = FileMode.Create;
            if (!overwrite)
            {
                fileMode = FileMode.CreateNew;
            }

            var fileStream = new FileStream(filePath, fileMode);
            return fileStream;
        }

        /// <summary>
        /// Eases construction of a new <see cref="FileStream"/> for reading.
        /// </summary>
        public FileStream NewRead(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return fileStream;
        }

        public FileStream OpenRead(string filePath)
        {
            var fileStream = File.OpenRead(filePath);
            return fileStream;
        }
    }
}