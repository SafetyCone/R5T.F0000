using System;

using R5T.T0131;


namespace R5T.F0000
{
    [ValuesMarker]
    public partial interface IStrings : IValuesMarker,
        Z0000.IStrings
    {
        public string TextDisplaySectionSeparator => "\n***\n";

        private static readonly Lazy<string> zTab_AsSpaces = new Lazy<string>(() => Instances.StringOperator.GetTabAsSpaces());

        /// <inheritdoc cref="Z0000.IValues.DefaultTabSpacesCount_Const"/>
        public string Tab_AsSpaces => IStrings.zTab_AsSpaces.Value;

        public string Tab_AsSpaces_TextRepresentation => "<tab-spaces>";
    }
}
