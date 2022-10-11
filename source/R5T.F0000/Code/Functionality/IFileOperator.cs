using System;
using System.Collections.Generic;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Actually reads all lines. The <see cref="File.ReadLines(string)"/> method omits blank lines, instead adding the new line character to the previous line!
		/// </summary>
		public string[] ActuallyReadAllLines(string filePath)
		{
			var text = File.ReadAllText(filePath);

			if (Instances.StringOperator.IsEmpty(text))
			{
				return Array.Empty<string>();
			}

			var lines = text.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None);
			return lines;
		}

		/// <summary>
		/// Ease of use name for the <see cref="ActuallyReadAllLines(string)"/> method.
		/// </summary>
		public string[] ReadAllLinesSynchronous(string filePath)
		{
			var lines = this.ActuallyReadAllLines(filePath);
			return lines;
		}

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