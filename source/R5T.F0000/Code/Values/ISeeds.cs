using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface ISeeds : IValuesMarker
	{
		public int Default => ISeeds.Default_Constant;
		public const int Default_Constant = ISeeds.Pi_Constant;

		public int Pi => ISeeds.Pi_Constant;
		public const int Pi_Constant = 31415;
	}
}