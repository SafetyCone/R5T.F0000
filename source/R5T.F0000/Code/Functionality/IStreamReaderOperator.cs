using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IStreamReaderOperator : IFunctionalityMarker
	{
		public StreamReader From(string filePath)
		{
			var output = new StreamReader(filePath);
			return output;
		}

		public StreamReader From(Stream stream)
		{
			var output = new StreamReader(stream);
			return output;
		}

		/// <summary>
		/// Quality-of-life overload for <see cref="From(string)"/>.
		/// </summary>
		public StreamReader GetNew(string filePath)
		{
			var output = this.From(filePath);
			return output;
		}
	}
}