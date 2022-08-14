using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IStreamReaderOperator : IFunctionalityMarker
	{
		public StreamReader GetNew(string filePath)
		{
			var output = new StreamReader(filePath);
			return output;
		}
	}
}