using System;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IVersionOperator : IFunctionalityMarker,
		L0053.IVersionOperator
	{
		public Version From_Major_Minor_Build(string major_minor_build)
		{
			var version = Version.Parse(major_minor_build);
			return version;
		}

		/// <summary>
		/// Determines if the version is the <see cref="L0066.IVersions.None"/> value.
		/// </summary>
		public bool IsNone(Version version)
		{
			var isNone = version == Instances.Versions.None;
			return isNone;
		}

        public Version Parse_WithoutHandlingVersionIndicator(string versionString)
        {
            var output = Version.Parse(versionString);
            return output;
        }

		/// <summary>
		/// Quality-of-life overload for <see cref="L0053.IVersionOperator.Parse(string)"/>.
		/// </summary>
		public Version ToVersion(string value)
		{
			var output = this.Parse(value);
			return output;
		}
	}
}