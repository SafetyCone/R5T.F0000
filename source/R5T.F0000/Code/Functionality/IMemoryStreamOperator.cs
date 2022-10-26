using System;
using System.IO;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IMemoryStreamOperator : IFunctionalityMarker
	{
		public MemoryStream FromBytes(byte[] bytes)
        {
			var memoryStream = new MemoryStream(bytes);
			return memoryStream;
        }

		public async Task<MemoryStream> FromFile(string filePath)
		{
			var fileBytes = await Instances.FileOperator.ReadBytes(filePath);

			var memoryStream = Instances.MemoryStreamOperator.FromBytes(fileBytes);
			return memoryStream;
		}
	}
}