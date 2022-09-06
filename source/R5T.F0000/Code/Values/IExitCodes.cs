using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IExitCodes : IValuesMarker
	{
		public int Failure => Instances.Integers.One;
		public int Success => Instances.Integers.Zero;
	}
}