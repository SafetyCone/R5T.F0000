using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileOperator : IFunctionalityMarker,
        L0053.IFileOperator
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
            if (Instances.StringOperator.Is_Empty(text))
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

        public TextWriter Get_Writer(string filePath)
        {
            var output = Instances.StreamWriterOperator.NewWrite(filePath);
            return output;
        }

        public async Task CopyToFile(
			string filePath,
			Stream stream)
        {
			using var fileStream = FileStreamOperator.Instance.Open_Write(
				filePath);

			await stream.CopyToAsync(fileStream);
        }

		public bool HasByteOrderMark(
			string filePath)
        {
			var bytes = this.Read_Bytes_Synchronous(filePath);

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

        /// <inheritdoc cref="IStreamWriterOperator.WriteAllLines_Synchronous(string, IEnumerable{string}, bool)"/>
		public void WriteAllLines_Synchronous(
			string filePath,
			IEnumerable<string> lines,
			bool overwrite = IValues.DefaultOverwriteValue_Const)
		{
            FileSystemOperator.Instance.Ensure_DirectoryExists_ForFilePath(filePath);

            StreamWriterOperator.Instance.WriteAllLines_Synchronous(filePath, lines, overwrite);
		}

		/// <summary>
		/// Creates a file with nothing in it.
		/// </summary>
		public async Task WriteAnEmptyFile(string textFilePath)
        {
            FileSystemOperator.Instance.Ensure_DirectoryExists_ForFilePath(textFilePath);

            await this.WriteText(
				textFilePath,
				Instances.Strings.Empty);
        }

        /// <summary>
        /// Creates a file with nothing in it.
        /// </summary>
        public void WriteAnEmptyFile_Synchronous(string textFilePath)
        {
            FileSystemOperator.Instance.Ensure_DirectoryExists_ForFilePath(textFilePath);

            this.Write_Text_Synchronous(
                textFilePath,
                Instances.Strings.Empty);
        }

        /// <summary>
        /// Writes the provided texts (and only the provided text, with no trailing blank line) to a file.
        /// Texts are written sequentially, with no separating lines.
        /// </summary>
        public Task Write_Texts(
            string textFilePath,
            IEnumerable<string> texts)
        {
            FileSystemOperator.Instance.Ensure_DirectoryExists_ForFilePath(textFilePath);

            var text = StringOperator.Instance.Join(texts);

            return File.WriteAllTextAsync(
                textFilePath,
                text);
        }

        /// <inheritdoc cref="Write_Texts(string, IEnumerable{string})"/>
        public Task Write_Texts(
            string textFilePath,
            params string[] texts)
        {
            return this.Write_Texts(
                textFilePath,
                texts.AsEnumerable());
        }

        /// <inheritdoc cref="Write_Texts(string, IEnumerable{string})"/>
        public void Write_Texts_Synchronous(
            string textFilePath,
            IEnumerable<string> texts)
        {
            FileSystemOperator.Instance.Ensure_DirectoryExists_ForFilePath(textFilePath);

            var text = StringOperator.Instance.Join(texts);

            File.WriteAllText(
                textFilePath,
                text);
        }

        /// <inheritdoc cref="Write_Texts(string, IEnumerable{string})"/>
        public void Write_Texts_Synchronous(
            string textFilePath,
            params string[] lines)
        {
            this.Write_Texts_Synchronous(
                textFilePath,
                lines.AsEnumerable());
        }

        public async Task WriteText(
            string textFilePath,
            string text)
        {
            FileSystemOperator.Instance.Ensure_DirectoryExists_ForFilePath(textFilePath);

            await File.WriteAllTextAsync(
                textFilePath,
                text);
        }
    }
}