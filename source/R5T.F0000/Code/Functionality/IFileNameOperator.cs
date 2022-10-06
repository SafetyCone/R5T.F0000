using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileNameOperator : IFunctionalityMarker
	{
		public string AppendToFileNameStem(
			string fileName,
			string appendix)
		{
			var fileNameStem = Instances.FileNameOperator.GetFileNameStem(fileName);
			var fileExtension = Instances.FileNameOperator.GetFileExtension(fileName);

			var newFileNameStem = fileNameStem + appendix;

			var newFileName = Instances.FileNameOperator.GetFileName(
				newFileNameStem,
				fileExtension);

			return newFileName;
		}

		public string GetBackupCopyFileNameStem(string fileNameStem)
		{
			var output = $"{fileNameStem}-BAK";
			return output;
		}

		public string GetBackupCopyFileName(string fileName)
		{
			var fileNameStem = this.GetFileNameStem(fileName);
			var fileExtension = this.GetFileExtension(fileName);

			var backupCopyFileNameStem = this.GetBackupCopyFileNameStem(fileNameStem);

			var backupCopyFileName = this.GetFileName(backupCopyFileNameStem, fileExtension);
			return backupCopyFileName;
		}

		public string GetFileExtension(string fileName)
        {
			var output = Instances.FileExtensionOperator.GetFileExtension(fileName);
			return output;
		}

		public string GetFileName(string fileNameStem, string fileExtension)
        {
			var fileExtensionSeparator = Instances.FileExtensionOperator.GetFileExtensionSeparator();

			var output = $"{fileNameStem}{fileExtensionSeparator}{fileExtension}";
			return output;
		}

		public string GetFileNameStem(string fileName)
        {
			var fileExtensionSeparator = Instances.FileExtensionOperator.GetFileExtensionSeparator();

			var tokens = Instances.StringOperator.Split(
				fileExtensionSeparator,
				fileName,
				// Keep empty tokens since a valid file name might contain two file extension separators in a row (aka, a double period).
				StringSplitOptions.None);

			var exceptLastToken = Instances.EnumerableOperator.ExceptLast(tokens);

			var fileNameStem = Instances.StringOperator.Join(
				fileExtensionSeparator,
				exceptLastToken);

			return fileNameStem;
        }
	}
}