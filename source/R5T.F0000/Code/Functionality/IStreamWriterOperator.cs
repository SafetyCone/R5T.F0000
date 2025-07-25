using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IStreamWriterOperator : IFunctionalityMarker,
        L0066.IStreamWriterOperator
	{
        public async Task WriteAllLinesOneByOne(StreamWriter writer, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                await writer.WriteLineAsync(line);
            }
        }

        public async Task WriteAllLinesOneByOne(string filePath, IEnumerable<string> lines, bool overwrite = IValues.Overwrite_Default_Constant)
        {
            using var streamWriter = this.New_Write(filePath, overwrite);

            await this.WriteAllLinesOneByOne(streamWriter, lines);
        }

        public Task WriteAllLines(StreamWriter writer, IEnumerable<string> lines, string lineSeparator)
        {
            var text = Instances.StringOperator.Join(lineSeparator, lines);

            return writer.WriteAsync(text);
        }

        /// <summary>
        /// Joins lines into a single text string, then writes the text to a file.
        /// </summary>
        public void WriteAllLines_Synchronous(StreamWriter writer, IEnumerable<string> lines, string lineSeparator)
        {
            var text = Instances.StringOperator.Join(lineSeparator, lines);

            writer.Write(text);
        }

        public Task WriteAllLines(StreamWriter writer, IEnumerable<string> lines)
        {
            return this.WriteAllLines(writer, lines, Instances.Strings.NewLine_ForEnvironment);
        }

        public void WriteAllLines_Synchronous(StreamWriter writer, IEnumerable<string> lines)
        {
            this.WriteAllLines_Synchronous(writer, lines, Instances.Strings.NewLine_ForEnvironment);
        }

        public async Task WriteAllLines(string filePath, IEnumerable<string> lines, string lineSeparator, bool overwrite = IValues.Overwrite_Default_Constant)
        {
            using var writer = this.New_Write(filePath, overwrite);

            await this.WriteAllLines(writer, lines, lineSeparator);
        }

        /// <inheritdoc cref="WriteAllLines_Synchronous(StreamWriter, IEnumerable{string}, string)"/>
        public void WriteAllLines_Synchronous(string filePath, IEnumerable<string> lines, string lineSeparator, bool overwrite = IValues.Overwrite_Default_Constant)
        {
            using var writer = this.New_Write(filePath, overwrite);

            this.WriteAllLines_Synchronous(writer, lines, lineSeparator);
        }

        public Task WriteAllLines(string filePath, IEnumerable<string> lines, bool overwrite = IValues.Overwrite_Default_Constant)
        {
            return this.WriteAllLines(filePath, lines, Instances.Strings.NewLine_ForEnvironment, overwrite);
        }

        /// <inheritdoc cref="WriteAllLines_Synchronous(string, IEnumerable{string}, string, bool)"/>
        public void WriteAllLines_Synchronous(string filePath, IEnumerable<string> lines, bool overwrite = IValues.Overwrite_Default_Constant)
        {
            this.WriteAllLines_Synchronous(filePath, lines, Instances.Strings.NewLine_ForEnvironment, overwrite);
        }
    }
}