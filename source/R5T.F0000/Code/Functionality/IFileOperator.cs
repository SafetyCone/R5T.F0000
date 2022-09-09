using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileOperator : IFunctionalityMarker
	{
		/// <summary>
		/// WCreates a file with nothing in it.
		/// </summary>
		public void WriteAnEmptyFile(string filePath)
        {
			this.WriteText(
				filePath,
				Instances.Strings.Empty);
        }

		public void WriteText(
			string filePath,
			string text)
        {
			File.WriteAllText(
				filePath,
				text);
        }
	}
}