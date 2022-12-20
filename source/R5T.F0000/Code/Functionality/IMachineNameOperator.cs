using System;
using System.Collections.Generic;
using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IMachineNameOperator : IFunctionalityMarker
    {
        public string GetMachineName()
        {
            var machineName = Environment.MachineName;
            return machineName;
        }

        public TValue GetValueByMachineName<TValue>(
            IDictionary<string, TValue> valuesByMachineName,
            Func<TValue> defaultValueProvider)
        {
            var machineName = this.GetMachineName();

            if (valuesByMachineName.ContainsKey(machineName))
            {
                var output = valuesByMachineName[machineName];
                return output;
            }
            else
            {
                // Else, assume we are in a non-development environment, and all required files are in the executable directory.
                var output = defaultValueProvider();
                return output;
            }
        }

        public TOutput SwitchOnMachineName<TOutput>(
            IDictionary<string, Func<TOutput>> constructorsByMachineName,
            Func<TOutput> defaultValueProvider)
        {
            var machineName = this.GetMachineName();

            var constructorDefinedForMachineName = constructorsByMachineName.ContainsKey(machineName);

            var constructor = constructorDefinedForMachineName
                ? constructorsByMachineName[machineName]
                : defaultValueProvider
                ;

            var output = constructor();
            return output;
        }
    }
}
