using System;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IVersionOperator : IFunctionalityMarker
	{
		public int[] GetAllTokens(Version version)
        {
            var tokens = new[]
            {
				version.Major,
				version.Minor,
				version.Build,
				version.Revision,
			};

			return tokens;
        }

        public int GetDefinedTokenCount(Version version)
        {
			var undefinedVersionValue = this.GetUndefinedVersionPropertyValue();

			var tokens = this.GetAllTokens(version);

			var definedTokenCount = tokens
				.Where(this.IsDefinedVersionPropertyValue)
				.Count();

			return definedTokenCount;
        }

		/// <summary>
		/// Returns the value of a version property that is defined, but have the default value (which is 0, zero).
		/// </summary>
		public int GetDefaultVersionPropertyValue()
        {
			var output = Instances.Integers.Zero;
			return output;
        }

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
		public bool IsDefinedVersionPropertyValue(int versionPropertyValue)
		{
			var undefinedVersionPropertyValue = this.GetUndefinedVersionPropertyValue();

			// Use not-equal instead of greater than to avoid relying on knowledged that the undefined value is negative one.
			var output = versionPropertyValue != undefinedVersionPropertyValue;
			return output;
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

		/// <summary>
		/// Will throw if the major, minor, and build properties of version are not set.
		/// </summary>
		public string ToString_Major_Minor_Build_ThrowIfFewerTokens(Version version)
        {
			// This ToString() implementation throws if there are too few tokens.
			var output = version.ToString(3);
			return output;
		}

		public Version NormalizeTo_Major_Minor_Build(Version version)
        {
			var definedTokenCount = this.GetDefinedTokenCount(version);
			if (definedTokenCount > 2)
			{
				return version;
			}

			var defaultVersionPropertyValue = this.GetDefaultVersionPropertyValue();

			if (definedTokenCount > 1)
			{
				var outputVersion = new Version(version.Major, version.Minor, defaultVersionPropertyValue);
				return outputVersion;
			}

			if (definedTokenCount > 0)
			{
				var outputVersion = new Version(version.Major, defaultVersionPropertyValue, defaultVersionPropertyValue);
				return outputVersion;
			}
			else
			{
				var outputVersion = new Version(defaultVersionPropertyValue, defaultVersionPropertyValue, defaultVersionPropertyValue);
				return outputVersion;
			}
		}

		/// <summary>
		/// Will return X.Y.Z, and will not throw if the version defines fewer tokens.
		/// </summary>
		public string ToString_Major_Minor_Build_FewerTokensOk(Version version)
        {
			var normalizedVersion = this.NormalizeTo_Major_Minor_Build(version);

			var output = this.ToString_Major_Minor_Build_ThrowIfFewerTokens(normalizedVersion);
			return output;
        }

		/// <summary>
		/// Chooses <see cref="ToString_Major_Minor_Build_FewerTokensOk(Version)"/> as the default.
		/// </summary>
		public string ToString_Major_Minor_Build(Version version)
        {
			var output = this.ToString_Major_Minor_Build_FewerTokensOk(version);
			return output;
        }
	}
}