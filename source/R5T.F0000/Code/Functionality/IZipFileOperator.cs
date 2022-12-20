using System;
using System.IO.Compression;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IZipFileOperator : IFunctionalityMarker
    {
        public void CreateFromDirectory(
            string sourceDirectoryPath,
            string destinationZipFilePath)
        {
            ZipFile.CreateFromDirectory(
                sourceDirectoryPath,
                destinationZipFilePath);
        }
    }
}
