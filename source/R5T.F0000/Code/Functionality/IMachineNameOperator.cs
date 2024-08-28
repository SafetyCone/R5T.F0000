using System;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IMachineNameOperator : IFunctionalityMarker,
        L0066.IMachineNameOperator
    {
        public string GetMachineName()
        {
            var machineName = Environment.MachineName;
            return machineName;
        }
    }
}
