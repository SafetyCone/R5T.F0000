using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IStreamWriterOperator : IFunctionalityMarker
	{
        /// <summary>
        /// The <see cref="StreamWriter"/> class has a constructor that helpfully leaves the underlying stream open after writing. However, this constructor puts the argument to leave the underlying stream open at the end of the input arguments list, behind lots of values crazy random values.
        /// This method produces a <see cref="StreamWriter"/> that will leave the underlying stream open with the ease of the default constructor.
        /// 
        /// Note: Returned writer produces no BOM.
        /// </summary>
        public StreamWriter NewLeaveOpen(Stream stream)
        {
            // Note new UTF8Encoding(false), instead of Encoding.UTF8, to prevent random byte-order-marks (BOM) marks. This was a big problem in writing to existing memory streams since the odd-number of BOM bytes (3) would be placed where writing started, in the middle of the memory stream!
            var output = new StreamWriter(stream, new UTF8Encoding(false), IStreamReaderValues.DefaultBufferSize, true);
            return output;
        }

        /// <summary>
        /// The <see cref="StreamWriter"/> class has a constructor that helpfully leaves the underlying stream open after writing. However, this constructor puts the argument to leave the underlying stream open at the end of the input arguments list, behind lots of values crazy random values.
        /// This method produces a <see cref="StreamWriter"/> that will leave the underlying stream open with the ease of the default constructor.
        /// 
        /// Note: Returned writer produces byte-order-marks (BOM).
        /// </summary>
        public StreamWriter NewLeaveOpenAddBOM(Stream stream)
        {
            // Note new UTF8Encoding(false), instead of Encoding.UTF8, to prevent random byte-order-marks (BOM) marks. This was a big problem in writing to existing memory streams since the odd-number of BOM bytes (3) would be placed where writing started, in the middle of the memory stream!
            var output = new StreamWriter(stream, Encoding.UTF8, IStreamReaderValues.DefaultBufferSize, true);
            return output;
        }

        /// <summary>
        /// The <see cref="StreamWriter"/> class by default closes the underlying stream to which it writes. The <see cref="IStreamWriterOperator.NewLeaveOpen(Stream)"/> method creates a <see cref="StreamWriter"/> that will be left open.
        /// This method provides the default <see cref="StreamWriter"/> behavior, to allow library users to get in the habit of using the <see cref="IStreamWriterOperator"/> in all cases, and to make the behavior of the <see cref="StreamWriter"/> explicit.
        /// 
        /// Note: Returned writer produces no BOM.
        /// </summary>
        public StreamWriter NewCloseAfter(Stream stream)
        {
            // This constructor produces no BOM as proven in an ExaminingCSharp experiment.
            var output = new StreamWriter(stream);
            return output;
        }

        public StreamWriter NewWrite(string filePath, bool overwrite = IValues.DefaultOverwriteValue)
        {
            var stream = Instances.FileStreamOperator.NewWrite(filePath, overwrite);

            var output = this.NewCloseAfter(stream);
            return output;
        }

        public async Task WriteAllLinesOneByOne(StreamWriter writer, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                await writer.WriteLineAsync(line);
            }
        }

        public async Task WriteAllLinesOneByOne(string filePath, IEnumerable<string> lines, bool overwrite = IValues.DefaultOverwriteValue)
        {
            using (var streamWriter = this.NewWrite(filePath, overwrite))
            {
                await this.WriteAllLinesOneByOne(streamWriter, lines);
            }
        }

        public Task WriteAllLines(StreamWriter writer, IEnumerable<string> lines, string lineSeparator)
        {
            var text = Instances.StringOperator.Join(lineSeparator, lines);

            return writer.WriteAsync(text);
        }

        public void WriteAllLinesSynchronous(StreamWriter writer, IEnumerable<string> lines, string lineSeparator)
        {
            var text = Instances.StringOperator.Join(lineSeparator, lines);

            writer.Write(text);
        }

        public Task WriteAllLines(StreamWriter writer, IEnumerable<string> lines)
        {
            return this.WriteAllLines(writer, lines, Instances.Strings.NewLineForEnvironment);
        }

        public void WriteAllLinesSynchronous(StreamWriter writer, IEnumerable<string> lines)
        {
            this.WriteAllLinesSynchronous(writer, lines, Instances.Strings.NewLineForEnvironment);
        }

        public async Task WriteAllLines(string filePath, IEnumerable<string> lines, string lineSeparator, bool overwrite = IValues.DefaultOverwriteValue)
        {
            using (var writer = this.NewWrite(filePath, overwrite))
            {
                await this.WriteAllLines(writer, lines, lineSeparator);
            }
        }

        public void WriteAllLinesSynchronous(string filePath, IEnumerable<string> lines, string lineSeparator, bool overwrite = IValues.DefaultOverwriteValue)
        {
            using (var writer = this.NewWrite(filePath, overwrite))
            {
                this.WriteAllLinesSynchronous(writer, lines, lineSeparator);
            }
        }

        public Task WriteAllLines(string filePath, IEnumerable<string> lines, bool overwrite = IValues.DefaultOverwriteValue)
        {
            return this.WriteAllLines(filePath, lines, Instances.Strings.NewLineForEnvironment, overwrite);
        }

        public void WriteAllLinesSynchronous(string filePath, IEnumerable<string> lines, bool overwrite = IValues.DefaultOverwriteValue)
        {
            this.WriteAllLinesSynchronous(filePath, lines, Instances.Strings.NewLineForEnvironment, overwrite);
        }
    }
}