using System;

using R5T.T0131;
using R5T.Z0000;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IValues : IValuesMarker,
		L0053.IValues
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

		public const int NoLimitMaximumResultsCount_Constant = -1;
		public int NoLimitMaximumResultsCount => IValues.NoLimitMaximumResultsCount_Constant;

		public const string ExplicitNone_Constant = "<None>";
		public string ExplicitNone => IValues.ExplicitNone_Constant;

        /// <summary>
        /// Version strings can have a 'v' as a leading version indicator (ex: v4.0.30319).
        /// </summary>
        public const char LeadingVersionIndicator_Constant = ICharacters.v_Lowercase_Constant;

		/// <inheritdoc cref="LeadingVersionIndicator_Constant"/>
		public char LeadingVersionIndicator => LeadingVersionIndicator_Constant;
    }
}