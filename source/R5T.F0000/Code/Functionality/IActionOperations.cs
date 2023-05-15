using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IActionOperations : IFunctionalityMarker
    {
        public void DoNothing_Synchronous<T>(T value)
        {
            // Do nothing.
        }

        public Task DoNothing<T>(T value)
        {
            // Do nothing.
            return Task.CompletedTask;
        }
    }
}
