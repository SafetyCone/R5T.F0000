using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IXmlPathOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Determines if the XML file path meets the requirements for being an XML file path (i.e. ends with the <see cref="Z0010.Platform.IFileExtensions.Xml"/> XML file extension).
		/// NOTE: Does <i>not</i> check if the file exists, or if the file contents meet the requirements of being an XML file. Merely checks the path.
		/// To check if the file contents meet the requirements of being an XML file, use an XML file operator (for example, <see cref="IXmlFileOperator.IsXmlFile(string)"/>).
		/// </summary>
		public bool IsSolutionFilePath(
			string possibleSolutionFilePath)
		{
			var isSolutionFilePath = Instances.PathOperator.Has_FileExtension(
				possibleSolutionFilePath,
				Instances.FileExtensions.Xml);

			return isSolutionFilePath;
		}
	}
}