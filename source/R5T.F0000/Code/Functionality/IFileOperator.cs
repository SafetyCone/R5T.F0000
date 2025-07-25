using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0143;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileOperator : IFunctionalityMarker,
        L0066.IFileOperator
	{
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0066.IFileOperator _L0066 => L0066.FileOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public async Task CopyToFile(
			string filePath,
			Stream stream)
        {
			using var fileStream = FileStreamOperator.Instance.Open_Write(
				filePath);

			await stream.CopyToAsync(fileStream);
        }

		public StreamWriter NewWrite_Text(
			string filePath,
            bool overwrite = IValues.Overwrite_Default_Constant)
		{
			var output = StreamWriterOperator.Instance.New_Write(
				filePath);

			return output;
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

        /// <inheritdoc cref="IStreamWriterOperator.WriteAllLines_Synchronous(string, IEnumerable{string}, bool)"/>
		public void WriteAllLines_Synchronous(
			string filePath,
			IEnumerable<string> lines,
			bool overwrite = IValues.Overwrite_Default_Constant)
		{
            FileSystemOperator.Instance.Ensure_DirectoryExists_ForFilePath(filePath);

            StreamWriterOperator.Instance.WriteAllLines_Synchronous(filePath, lines, overwrite);
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