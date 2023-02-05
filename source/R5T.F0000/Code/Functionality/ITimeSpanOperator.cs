using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ITimeSpanOperator : IFunctionalityMarker
	{
		/// <summary>
		/// The offset returned satisfies:
		/// local time = UTC time + offset.
		/// </summary>
		/// <returns></returns>
		public TimeSpan GetOffsetFromUtc()
        {
			var offsetFromUtc = DateTimeOffset.Now.Offset;
			return offsetFromUtc;
        }

		public string ToString_NumberOfSeconds_WithMilliseconds(TimeSpan timeSpan)
		{
			var totalSeconds = timeSpan.TotalSeconds;

			var representation = Instances.DoubleOperator.ToString_WithThreeDecimalPlaces(totalSeconds);
			return representation;
		}
	}
}