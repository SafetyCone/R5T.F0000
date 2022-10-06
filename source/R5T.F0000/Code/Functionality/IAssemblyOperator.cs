using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IAssemblyOperator : IFunctionalityMarker
	{
        public void ForTypes(
            Assembly assembly,
            Func<TypeInfo, bool> typeSelector,
            Action<TypeInfo> action)
        {
            var types = this.SelectTypes(assembly, typeSelector);

            types.ForEach(typeInfo => action(typeInfo));
        }

        public IEnumerable<TypeInfo> SelectTypes(
            Assembly assembly,
            Func<TypeInfo, bool> typeSelector)
        {
            var output = assembly.DefinedTypes
                .Where(typeSelector)
                ;

            return output;
        }
    }
}