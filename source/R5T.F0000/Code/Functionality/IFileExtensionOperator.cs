using System;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileExtensionOperator : IFunctionalityMarker
	{
		public string AddFileExtension(string fileNameStem, string fileExtension)
		{
			var output = Instances.FileNameOperator.GetFileName(fileNameStem, fileExtension);
			return output;
		}

		public string GetFileExtension(string fileName)
		{
			var fileExtensionSeparator = Instances.FileExtensionOperator.GetFileExtensionSeparator();

			var tokens = Instances.StringOperator.Split(
				fileExtensionSeparator,
				fileName,
				// Windows file names cannot end with a file extension separator (a period) or a space, but non-Windows file names can. In that case we want the empty or spaced file extension.
				// So keep empty file extensions, and do not trim file extensions.
				StringSplitOptions.None);

			// File extension is the last token.
			var fileExtension = tokens.Last();
			return fileExtension;
		}

		public char GetFileExtensionSeparator_Char()
        {
			var output = Instances.Characters.Period;
			return output;
        }

		/// <summary>
		/// Chooses <see cref="GetFileExtensionSeparator_Char"/> as the default.
		/// </summary>
		public char GetFileExtensionSeparator()
        {
			var output = this.GetFileExtensionSeparator_Char();
			return output;
        }

		public string GetFileName(string fileNameStem, string fileExtension)
        {
			var output = Instances.FileNameOperator.GetFileName(fileNameStem, fileExtension);
			return output;
        }

		public string GetFileNameStem(string fileName)
        {
			var output = Instances.FileNameOperator.GetFileNameStem(fileName);
			return output;
        }

		/// <summary>
		/// Quality-of-life alias for <see cref="IPathOperator.HasFileExtension(string, string)"/>.
		/// </summary>
		public bool HasFileExtension(
			string filePath,
			string fileExtension)
		{
			var output = Instances.PathOperator.HasFileExtension(
				filePath,
				fileExtension);

			return output;
		}
	}
}