using System;

using R5T.T0131;


namespace R5T.F0000
{
    [ValuesMarker]
    public partial interface IStrings : IValuesMarker,
        Z0000.IStrings
    {
        public string Tab_AsSpaces => Instances.StringOperator.GetTabAsSpaces();
    }
}
