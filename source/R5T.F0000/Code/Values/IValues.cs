using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IValues : IValuesMarker
	{
		private static readonly Lazy<byte[]> zByteOrderMark = new Lazy<byte[]>(() => new byte[]
		{
			239,
			187,
			191
		});

		/// <summary>
		/// The byte-order-mark is a series of three bytes:
		/// 0xEF, 239, ï
		/// 0xBB, 187, »
		/// 0xBF, 191, ¿
		/// </summary>
		public byte[] ByteOrderMark => IValues.zByteOrderMark.Value;
		public const bool DefaultOverwriteValue_Const = true;
		public bool DefaultOverwriteValue => IValues.DefaultOverwriteValue_Const;

		public const int NoLimitMaximumResultsCount_Constant = -1;
		public int NoLimitMaximumResultsCount => IValues.NoLimitMaximumResultsCount_Constant;
	}
}