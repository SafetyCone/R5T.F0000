using System;

using R5T.T0132;


namespace R5T.F0000.F001
{
	public partial interface ITimeOnlyOperator : IFunctionalityMarker
	{
        public static partial class Documentation
        {
            /// <summary>
            /// If the time is after now, then the next time occurs today. Else if the time occurs before now, then the next time occurs tomorrow.
            /// </summary>
            public static readonly object NexDateAfterTime;
        }
    }
}