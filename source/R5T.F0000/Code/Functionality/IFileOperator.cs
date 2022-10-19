using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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

		public bool HasByteOrderMark(
			string filePath)
        {
			var bytes = this.ReadBytes_Synchronous(filePath);

			var byteOrderMark = Instances.Values.ByteOrderMark;

			var hasByteOrderMark = Instances.EnumerableOperator.StartsWith(
				bytes,
				byteOrderMark);

			return hasByteOrderMark;
        }

		/// <summary>
		/// Ease of use name for the <see cref="ActuallyReadAllLines(string)"/> method.
		/// </summary>
		public string[] ReadAllLines_Synchronous(string filePath)
		{
			var lines = this.ActuallyReadAllLines(filePath);
			return lines;
		}

		public Task<byte[]> ReadBytes(string filePath)
		{
			return File.ReadAllBytesAsync(filePath);
		}

		public byte[] ReadBytes_Synchronous(string filePath)
        {
			var bytes = File.ReadAllBytes(filePath);
			return bytes;
        }

		public string ReadText(string filePath)
        {
			var text = File.ReadAllText(filePath);
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