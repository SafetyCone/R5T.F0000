using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IComparisonResults : IValuesMarker
	{
        /// <summary>
        /// Indicates that x is less than y.
        /// <para><inheritdoc cref="L0066.Documentation.CompareToXY" path="/summary"/></para>
        /// </summary>
        public int LessThan => -1;
        /// <summary>
        /// Indicates that x is greater than y.
        /// <para><inheritdoc cref="L0066.Documentation.CompareToXY" path="/summary"/></para>
        /// </summary>
        public int GreaterThan => 1;
        public int EqualTo => 0;
    }
}