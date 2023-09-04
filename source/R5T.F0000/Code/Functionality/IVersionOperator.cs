using System;
using System.Linq;

using R5T.T0132;

using R5T.F0000.Extensions;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IVersionOperator : IFunctionalityMarker,
		L0053.IVersionOperator
	{
		public string Ensure_NotVersionIndicated(string versionString)
		{
			var hasVersionIndicator = this.Has_LeadingVersionIndicator(versionString);

			var output = hasVersionIndicator
				? this.Remove_LeadingVersionIndicator_Unchecked(versionString)
				: versionString
				;

			return output;
		}

		public Version From(int major, int minor, int build)
        {
			var version = new Version(major, minor, build);
			return version;
        }

		/// <summary>
		/// Chooses <see cref="From_Major_Minor_Build(string)"/> as the default.
		/// </summary>
		public Version From(string major_minor_build)
		{
			var version = this.From_Major_Minor_Build(major_minor_build);
			return version;
		}

		public Version From_Major_Minor_Build(string major_minor_build)
		{
			var version = Version.Parse(major_minor_build);
			return version;
		}

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
		/// Robust, in the sense that if the version string is null or empty, no exception will be thrown.
		/// Instead, false will be return.
		/// </summary>
		public bool Has_LeadingVersionIndicator(string versionString)
		{
			if(Instances.StringOperator.IsNullOrEmpty(versionString))
			{
				return false;
			}

			var firstCharacter = versionString.First();

			var output = firstCharacter == Instances.Values.LeadingVersionIndicator;
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
			if(definedTokenCount > 3)
			{
				// Normalize to three.
                var outputVersion = new Version(version.Major, version.Minor, version.Build);
                return outputVersion;
            }

			// If not 4 tokens, but greater than 2, then it is 3.
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

        public Version Parse_WithoutHandlingVersionIndicator(string versionString)
        {
            var output = Version.Parse(versionString);
            return output;
        }

        /// <summary>
        /// Can handle version indicated strings (ex: v4.0.30319).
        /// </summary>
        public Version Parse(string versionString)
		{
			var ensuredVersionString = this.Ensure_NotVersionIndicated(versionString);

			var output = Version.Parse(ensuredVersionString);
			return output;
		}

		/// <summary>
		/// Unchecked in the sense that no check is performed that the input is not null or empty, or that the input actually begins with the leading version indicator.
		/// </summary>
        public string Remove_LeadingVersionIndicator_Unchecked(string versionIndicatedString)
        {
            var output = versionIndicatedString.Except_First();
			return output;
        }

        /// <summary>
        /// Version indicated strings begin with a 'v'.
        /// This method removes that V.
        /// </summary>
        public string Remove_LeadingVersionIndicator_Strict(string versionIndicatedString)
		{
			this.Verify_HasLeadingVersionIndicator(versionIndicatedString);

			var output = this.Remove_LeadingVersionIndicator_Unchecked(versionIndicatedString);
			return output;
		}

		/// <summary>
		/// Chooses <see cref="Remove_LeadingVersionIndicator_Strict(string)"/> as the default.
		/// </summary>
		public string Remove_LeadingVersionIndicator(string versionIndicatedString)
		{
			return this.Remove_LeadingVersionIndicator_Strict(versionIndicatedString);
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
		/// <inheritdoc cref="ToString_Major_Minor_Build_FewerTokensOk(Version)" path="/summary"/>
		/// </summary>
		/// <remarks>
        /// Chooses <see cref="ToString_Major_Minor_Build_FewerTokensOk(Version)"/> as the default.
        /// </remarks>
        public string ToString_Major_Minor_Build(Version version)
        {
			var output = this.ToString_Major_Minor_Build_FewerTokensOk(version);
			return output;
        }

		/// <summary>
		/// Quality-of-life overload for <see cref="Parse(string)"/>.
		/// </summary>
		public Version ToVersion(string value)
		{
			var output = this.Parse(value);
			return output;
		}

		public void Verify_HasLeadingVersionIndicator(string versionString)
		{
            var hasLeadingVersionIndicator = this.Has_LeadingVersionIndicator(versionString);
            if (!hasLeadingVersionIndicator)
            {
                throw new Exception($"Version string did not have a leading version indicator ('{Instances.Values.LeadingVersionIndicator}').");
            }
        }
	}
}