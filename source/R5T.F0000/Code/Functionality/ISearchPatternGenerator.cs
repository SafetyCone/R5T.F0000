using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ISearchPatternGenerator : IFunctionalityMarker
	{
        public string AllFilesStartingWith(string fileNameStart)
        {
            var output = $"{fileNameStart}{Instances.SearchPatterns.All}";
            return output;
        }

        public string AllFilesWithExtension(string fileExtension)
        {
            var output = $"{Instances.SearchPatterns.All}{fileExtension}";
            return output;
        }
    }
}