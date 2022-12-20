using System;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IActionOperations : IFunctionalityMarker
    {
        public void DoNothing<T>(T value)
        {
            // Do nothing.
        }
    }
}
