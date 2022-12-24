using System;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface ICurrentDirectoryOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Sets the current directory to the executable directory.
        /// </summary>
        public void SetCurrentDirectory_Default()
        {
            var executableDirectoryPath = ExecutablePathOperator.Instance.GetExecutableDirectoryPath();

            this.SetCurrentDirectory(executableDirectoryPath);
        }

        public void SetCurrentDirectory(string directoryPath)
        {
            Environment.CurrentDirectory = directoryPath;
        }
    }
}
