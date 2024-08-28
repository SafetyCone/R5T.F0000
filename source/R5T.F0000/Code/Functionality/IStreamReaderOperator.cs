using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IStreamReaderOperator : IFunctionalityMarker,
		L0066.IStreamReaderOperator
	{
		public StreamReader GetNew(string filePath)
			=> this.Get_New(filePath);
	}
}