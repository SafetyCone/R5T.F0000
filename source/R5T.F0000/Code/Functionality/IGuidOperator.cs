using System;

using R5T.T0132;

using GuidDocumentation = R5T.Y0000.Documentation.ForGuid;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public interface IGuidOperator : IFunctionalityMarker
    {
        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.B_Format"/>
        /// </summary>
        public string ToString_B_Format(Guid guid)
        {
            var output = guid.ToString("B");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.B_Uppercase_Format"/>
        /// </summary>
        public string ToString_B_Uppercase_Format(Guid guid)
        {
            var output = this.ToString_B_Format(guid).ToUpperInvariant();
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.D_Format"/>
        /// </summary>
        public string ToString_D_Format(Guid guid)
        {
            var output = guid.ToString("D");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.D_Uppercase_Format"/>
        /// </summary>
        public string ToString_D_Uppercase_Format(Guid guid)
        {
            var output = this.ToString_D_Format(guid).ToUpperInvariant();
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.N_Format"/>
        /// </summary>
        public string ToString_N_Format(Guid guid)
        {
            var output = guid.ToString("N");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.P_Format"/>
        /// </summary>
        public string ToString_P_Format(Guid guid)
        {
            var output = guid.ToString("P");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.X_Format"/>
        /// </summary>
        public string ToString_X_Format(Guid guid)
        {
            var output = guid.ToString("X");
            return output;
        }

        /// <summary>
        /// <para>The standard format is default (D uppercase) format.</para>
        /// <inheritdoc cref="GuidDocumentation.D_Uppercase_Format"/>
        /// </summary>
        public string ToString_Standard(Guid guid)
        {
            var output = this.ToString_D_Uppercase_Format(guid);
            return output;
        }

        /// <summary>
        /// <para>The default is the D format.</para>
        /// <inheritdoc cref="GuidDocumentation.D_Format"/>
        /// </summary>
        public string ToString(Guid guid)
        {
            var output = guid.ToString();
            return output;
        }

        public Guid Parse(string guidString)
        {
            var output = Guid.Parse(guidString);
            return output;
        }
    }
}
