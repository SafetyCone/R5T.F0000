using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IDoubleOperator : IFunctionalityMarker,
        L0066.IDoubleOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0066.IDoubleOperator _L0066 => L0066.DoubleOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
