using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IVersions : IValuesMarker
	{
		/// <summary>
		/// The default version (for assuming when no version is present) is 1.0.0.
		/// </summary>
		public Version Default => new Version(1, 0, 0);

		/// <summary>
		/// The none version is just null (since Version is a reference type).
		/// </summary>
		public Version None => null;

#pragma warning disable IDE1006 // Naming Styles

        public Version _1_0_0 => new Version(1, 0, 0);

#pragma warning restore IDE1006 // Naming Styles
    }
}