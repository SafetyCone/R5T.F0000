using System;

using R5T.T0132;


namespace R5T.F0000.Construction
{
	[FunctionalityMarker]
	public partial interface IFileOperations : IFunctionalityMarker
	{
		/// <summary>
		/// History of the byte-order-mark:
		/// * Why the particular sequence 239, 187, 191? It was the ZERO WIDTH NO-BREAK SPACE (ZWNBSP) character, which is no longer in use in favor of U+2060 WORD JOINER.
		/// * https://www.reddit.com/r/programming/comments/g2pmr/the_byte_order_mark/
		/// * https://www.w3.org/International/questions/qa-byte-order-mark
		/// </summary>
		public void HasByteOrderMark()
        {
			var filePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.C0003\source\R5T.C0003.sln";

			byte byteOrderMark01 = 0xEF; // 239, ï
			byte byteOrderMark02 = 0xBB; // 187, »
			byte byteOrderMark03 = 0xBF; // 191, ¿

			var bytes = F0000.Instances.FileOperator.Read_Bytes_Synchronous(filePath);

			var hasByteOrderMark01 = bytes[0] == byteOrderMark01;
			var hasByteOrderMark02 = bytes[1] == byteOrderMark02;
			var hasByteOrderMark03 = bytes[2] == byteOrderMark03;

			Console.WriteLine($"{hasByteOrderMark01}{hasByteOrderMark02}{hasByteOrderMark03}");
		}
	}
}