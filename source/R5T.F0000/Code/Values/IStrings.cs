using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.F0000
{
    [ValuesMarker]
    public partial interface IStrings : IValuesMarker,
        Z0000.IStrings
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Z0000.IStrings _Z0000 => Z0000.Strings.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string TextDisplaySectionSeparator => "\n***\n";

        private static readonly Lazy<string> zTab_AsSpaces = new Lazy<string>(() => Instances.StringOperator.GetTabAsSpaces());

        /// <inheritdoc cref="Z0000.IValues.DefaultTabSpacesCount_Const"/>
        public string Tab_AsSpaces => IStrings.zTab_AsSpaces.Value;

        public string Tab_AsSpaces_TextRepresentation => "<tab-spaces>";
    }
}
