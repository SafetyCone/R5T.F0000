using System;

using R5T.T0131;


namespace R5T.F0000
{
    [ValuesMarker]
    public partial interface IRegularExpressionPatterns : IValuesMarker
    {
        /// <summary>
        /// Includes any character, except close brace, inside of braces.
        /// Excluding the close brace is required to capture both A and B in "{A} and {B}". Otherwise you would capture "A} and {B".
        /// </summary>
        // language=regex
        public string AnythingInsideBraces => "{[^}]*}";
    }
}
