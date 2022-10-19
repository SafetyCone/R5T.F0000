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

        public string ToString_Upper(bool value)
        {
            var representation = value
                ? Z0000.Instances.Strings.True_Uppercase
                : Z0000.Instances.Strings.False_UpperCase
                ;

            return representation;
        }

        /// <summary>
        /// Pascal case matches the default <see cref="Boolean.ToString()"/> behavior.
        /// </summary>
        public string ToString_PascalCase(bool value)
        {
            /// Note: default <see cref="Boolean.ToString()"/> behavior produces the Pascal case values.
            var representation = value
                ? Z0000.Instances.Strings.True_PascalCase
                : Z0000.Instances.Strings.False_PascalCase
                ;

            return representation;
        }

        /// <summary>
        /// Chooses <see cref="ToString_PascalCase(bool)"/> as the default to match the <see cref="Boolean.ToString()"/> behavior.
        /// </summary>
        public string ToString(bool value)
        {
            /// Default <see cref="Boolean.ToString()"/> behavior produces the <see cref="Z0000.IStrings.True_PascalCase"/> and <see cref="Z0000.IStrings.False_PascalCase"/> values.
            var representation = this.ToString_PascalCase(value);
            return representation;
        }
    }
}