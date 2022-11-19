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

		public async Task CopyToFile(
			string filePath,
			Stream stream)
        {
			using var fileStream = FileStreamOperator.Instance.NewWrite(
				filePath);

			await stream.CopyToAsync(fileStream);
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
			var fileBytes = File.ReadAllBytesAsync(filePath);
			return fileBytes;
		}

		public byte[] ReadBytes_Synchronous(string filePath)
        {
			var fileBytes = File.ReadAllBytes(filePath);
			return fileBytes;
        }

		public async Task<MemoryStream> ReadBytesInMemory(string filePath)
		{
			var fileBytes = await this.ReadBytes(filePath);

            var memoryStream = Instances.MemoryStreamOperator.FromBytes(fileBytes);
			return memoryStream;
        }

        public string ReadText_Synchronous(string filePath)
        {
			var text = File.ReadAllText(filePath);
			return text;
        }

		public Task<string> ReadText(string filePath)
		{
			return File.ReadAllTextAsync(filePath);
		}

		public void WriteAllLines_Synchronous(
			string filePath,
			IEnumerable<string> lines,
			bool overwrite = IValues.DefaultOverwriteValue_Const)
		{
			StreamWriterOperator.Instance.WriteAllLines_Synchronous(filePath, lines, overwrite);
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

		public Task WriteLines(
			string textFilePath,
			IEnumerable<string> lines)
		{
			return File.WriteAllLinesAsync(
				textFilePath,
				lines);
		}

		public void WriteLines_Synchronous(
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