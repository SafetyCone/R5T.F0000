using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using R5T.L0089.T000;
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

        public void ForAllTypes(
            Assembly assembly,
            Action<TypeInfo> action)
        {
            this.ForTypes(
                assembly,
                // Select all types.
                type => true,
                action);
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

        public TypeInfo GetType(
            Assembly assembly,
            string namespacedTypeName)
        {
            var hasType = this.HasType(
                assembly,
                namespacedTypeName);

            var typeInfo = Instances.WasFoundOperator.Get_Result_OrExceptionIfNotFound(
                hasType,
                $"{namespacedTypeName}: type not found.");

            return typeInfo;
        }

        public WasFound<TypeInfo> HasType(
            Assembly assembly,
            string namespacedTypeName)
        {
            var typeOrDefault = this.SelectTypes(
                assembly,
                TypeOperator.Instance.WhereNamespacedTypeNameIs(namespacedTypeName))
                .SingleOrDefault();

            var wasFound = WasFound.From(typeOrDefault);
            return wasFound;
        }
    }
}