using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IOrderOperator : IFunctionalityMarker,
        L0066.IOrderOperator
    {
        private static Internal.IOrderOperator Internal => F0000.Internal.OrderOperator.Instance;
    }
}


namespace R5T.F0000.Internal
{
    [FunctionalityMarker]
    public partial interface IOrderOperator : IFunctionalityMarker,
        L0066.IOrderOperator
    {
        
    }
}