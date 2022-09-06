using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IVersionOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Returns the value of undefined version properties (which is -1, negative one).
		/// </summary>
		public int GetUndefinedVersionPropertyValue()
        {
			var output = Instances.Integers.NegativeOne;
			return output;
		}

		public char GetVersionTokenSeparator()
        {
			var output = Z0000.Instances.Characters.Period;
			return output;
        }

		/// <summary>
		/// Determines if the version is the <see cref="IVersions.None"/> value.
		/// </summary>
		public bool IsNone(Version version)
		{
			var isNone = version == Instances.Versions.None;
			return isNone;
		}

		/// <summary>
		/// Determines if the version property value is the value returned by <see cref="GetUndefinedVersionPropertyValue"/> (which is -1, negative one).
		/// </summary>
		public bool IsUndefinedVersionPropertyValue(int versionPropertyValue)
        {
			var undefinedVersionPropertyValue = this.GetUndefinedVersionPropertyValue();

			var output = versionPropertyValue == undefinedVersionPropertyValue;
			return output;
        }

		public string ToString_Major_Minor_Build(Version version)
        {
			var output = version.ToString(3);
			return output;
        }
	}
}