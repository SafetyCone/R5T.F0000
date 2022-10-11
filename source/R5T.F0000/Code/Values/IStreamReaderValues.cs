using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IStreamReaderValues : IValuesMarker, IValues
	{
		public const int DefaultBufferSize = 1024;
	}
}