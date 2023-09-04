using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileNameOperator : IFunctionalityMarker,
		L0053.IFileNameOperator
	{
		public string AppendToFileNameStem(
			string fileName,
			string appendix)
		{
			var fileNameStem = Instances.FileNameOperator.GetFileNameStem(fileName);
			var fileExtension = Instances.FileNameOperator.GetFileExtension(fileName);

			var newFileNameStem = fileNameStem + appendix;

			var newFileName = Instances.FileNameOperator.Get_FileName(
				newFileNameStem,
				fileExtension);

			return newFileName;
		}

        /// <summary>
        /// Returns the XML documentation file name given the assembly name.
        /// </summary>
        public string Get_AssemblyDocumentationFileName(string assemblyName)
        {
            // Just append the "dll" file extension to the assembly name.
            var assemblyFileNameStem = this.Get_AssemblyFileNameStem(assemblyName);

            var assemblyDocumentationFileName = Instances.FileNameOperator.Get_FileName(
                assemblyFileNameStem,
                Instances.FileExtensions.Xml);

            return assemblyDocumentationFileName;
        }

        /// <inheritdoc cref="L0053.IAssemblyFileNameOperator.Get_AssemblyFileNameStem(string)"/>
        public string Get_AssemblyFileNameStem(string assemblyName)
		{
			return Instances.AssemblyFileNameOperator.Get_AssemblyFileNameStem(assemblyName);
		}

        /// <summary>
        /// Returns the DLL file name given the assembly name.
        /// </summary>
        public string Get_AssemblyFileName(string assemblyName)
		{
			// Just append the "dll" file extension to the assembly name.
			var assemblyFileNameStem = this.Get_AssemblyFileNameStem(assemblyName);

			var assemblyFileName = Instances.FileNameOperator.Get_FileName(
				assemblyFileNameStem,
				Instances.FileExtensions.Dll);

			return assemblyFileName;
		}

		public string GetBackupCopyFileNameStem(string fileNameStem)
		{
			var output = $"{fileNameStem}-{FileNameAffixes.Instance.BAK}";
			return output;
		}

		public string GetBackupCopyFileName(string fileName)
		{
			var fileNameStem = this.GetFileNameStem(fileName);
			var fileExtension = this.GetFileExtension(fileName);

			var backupCopyFileNameStem = this.GetBackupCopyFileNameStem(fileNameStem);

			var backupCopyFileName = this.Get_FileName(backupCopyFileNameStem, fileExtension);
			return backupCopyFileName;
		}

		public string GetFileExtension(string fileName)
        {
			var output = Instances.FileExtensionOperator.GetFileExtension(fileName);
			return output;
		}

		

		[Obsolete("Warning: uses System.IO.FileInfo, which has issues with paths of a different OS type. Use R5T.F0002.IPathOperator.GetFileName() instead.")]
		public string GetFileName_FromFilePath(string filePath)
		{
			var fileInfo = new FileInfo(filePath);

			var fileName = fileInfo.Name;
			return fileName;
		}

		public string GetFileNameStem(string fileName)
        {
			var fileExtensionSeparator = Instances.FileExtensionOperator.Get_FileExtensionSeparator();

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