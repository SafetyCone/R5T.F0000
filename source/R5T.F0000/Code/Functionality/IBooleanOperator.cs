using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IBooleanOperator : IFunctionalityMarker
	{
        public string ToString_Lower(bool value)
        {
            var representation = value
                ? Z0000.Instances.Strings.True_Lowercase
                : Z0000.Instances.Strings.False_Lowercase
                ;

            return representation;
        }

        public string ToString_Camelcase(bool value)
        {
            /// Default behavior produces the <see cref="Z0000.IStrings.True_Camelcase"/> and <see cref="Z0000.IStrings.False_Camelcase"/> values.
            var representation = value.ToString();
            return representation;
        }

        /// <summary>
        /// Chooses <see cref="ToString_Camelcase(bool)"/> as the default to match the <see cref="Boolean.ToString()"/> behavior.
        /// </summary>
        public string ToString(bool value)
        {
            var representation = this.ToString_Camelcase(value);
            return representation;
        }
    }
}