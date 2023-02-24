using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ISearchPatternGenerator : IFunctionalityMarker
	{
        public string AllDirectoriesStartingWith(string directoryNameStart)
        {
            var output = this.AllEntriesStartingWith(directoryNameStart);
            return output;
        }

        /// <summary>
        /// Entries are files and directories.
        /// </summary>
        public string AllEntriesStartingWith(string nameStart)
        {
            var output = $"{nameStart}{Instances.SearchPatterns.All}";
            return output;
        }

        public string AllFilesStartingWith(string fileNameStart)
        {
            var output = this.AllEntriesStartingWith(fileNameStart);
            return output;
        }

        public string AllFilesWithExtension(string fileExtension)
        {
            var output = $"{Instances.SearchPatterns.All}{fileExtension}";
            return output;
        }
    }
}