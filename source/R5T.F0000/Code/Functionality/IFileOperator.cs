using System;
using System.Collections.Generic;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileOperator : IFunctionalityMarker
	{
		public string ReadText(string textFilePath)
        {
			var text = File.ReadAllText(textFilePath);
			return text;
        }

		/// <summary>
		/// WCreates a file with nothing in it.
		/// </summary>
		public void WriteAnEmptyFile(string textFilePath)
        {
			this.WriteText(
				textFilePath,
				Instances.Strings.Empty);
        }

		public void WriteLines(
			string textFilePath,
			IEnumerable<string> lines)
		{
			File.WriteAllLines(
				textFilePath,
				lines);
		}

		public void WriteText(
			string textFilePath,
			string text)
        {
			File.WriteAllText(
				textFilePath,
				text);
        }
	}
}