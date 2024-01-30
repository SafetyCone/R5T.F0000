using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileNameOperator : IFunctionalityMarker,
		L0053.IFileNameOperator,
		L0071.IFileNameOperator
	{
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

        /// <inheritdoc cref="L0066.IAssemblyFileNameOperator.Get_AssemblyFileNameStem(string)"/>
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

		[Obsolete("Warning: uses System.IO.FileInfo, which has issues with paths of a different OS type. Use R5T.F0002.IPathOperator.GetFileName() instead.")]
		public string GetFileName_FromFilePath(string filePath)
		{
			var fileInfo = new FileInfo(filePath);

			var fileName = fileInfo.Name;
			return fileName;
		}
	}
}