using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.Z0000;

namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Actually reads all lines. The <see cref="File.ReadLines(string)"/> method omits blank lines, instead adding the new line character to the previous line!
		/// </summary>
		public async Task<string[]> ActuallyReadAllLines(string filePath)
		{
			var text = await File.ReadAllTextAsync(filePath);

            var lines = this.GetLinesFromText(text);
            return lines;
        }

        /// <inheritdoc cref="ActuallyReadAllLines(string)"/>
        public string[] ActuallyReadAllLines_Synchronous(string filePath)
        {
            var text = File.ReadAllText(filePath);

			var lines = this.GetLinesFromText(text);
			return lines;
        }

		public string[] GetLinesFromText(string text)
		{
            if (Instances.StringOperator.IsEmpty(text))
            {
                return Array.Empty<string>();
            }

            var lines = text.Split(
                new[]
                {
                    Strings.Instance.NewLine_NonWindows,
                    Strings.Instance.NewLine_Windows,
                },
                StringSplitOptions.None);

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

		public StreamWriter NewWrite_Text(
			string filePath,
            bool overwrite = IValues.DefaultOverwriteValue_Const)
		{
			var output = StreamWriterOperator.Instance.NewWrite(
				filePath);

			return output;
		}

        /// <summary>
        /// Ease of use name for the <see cref="ActuallyReadAllLines(string)"/> method.
        /// </summary>
        public async Task<string[]> ReadAllLines(string filePath)
        {
            var lines = await this.ActuallyReadAllLines(filePath);
            return lines;
        }

        /// <inheritdoc cref="ReadAllLines(string)"/>
        public string[] ReadAllLines_Synchronous(string filePath)
		{
			var lines = this.ActuallyReadAllLines_Synchronous(filePath);
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
            FileSystemOperator.Instance.EnsureDirectoryForFilePathExists(filePath);

            StreamWriterOperator.Instance.WriteAllLines_Synchronous(filePath, lines, overwrite);
		}

		/// <summary>
		/// WCreates a file with nothing in it.
		/// </summary>
		public void WriteAnEmptyFile(string textFilePath)
        {
            FileSystemOperator.Instance.EnsureDirectoryForFilePathExists(textFilePath);

            this.WriteText(
				textFilePath,
				Instances.Strings.Empty);
        }

        /// <summary>
        /// Writes the provided lines (and only the provided lines, with no trailing blank line) to a file.
        /// </summary>
        public Task WriteLines(
			string textFilePath,
			IEnumerable<string> lines)
		{
            FileSystemOperator.Instance.EnsureDirectoryForFilePathExists(textFilePath);

            var text = StringOperator.Instance.Join(
                Instances.Characters.NewLine,
                lines);

            return File.WriteAllTextAsync(
				textFilePath,
				text);
		}

		/// <inheritdoc cref="WriteLines(string, IEnumerable{string})"/>
		public void WriteLines_Synchronous(
			string textFilePath,
			IEnumerable<string> lines)
		{
            FileSystemOperator.Instance.EnsureDirectoryForFilePathExists(textFilePath);

			var text = StringOperator.Instance.Join(
				Instances.Characters.NewLine,
				lines);

            File.WriteAllText(
				textFilePath,
				text);
		}

		public void WriteText(
			string textFilePath,
			string text)
        {
			FileSystemOperator.Instance.EnsureDirectoryForFilePathExists(textFilePath);

			File.WriteAllText(
				textFilePath,
				text);
        }
	}
}