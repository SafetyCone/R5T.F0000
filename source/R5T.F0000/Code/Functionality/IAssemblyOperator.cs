using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using R5T.L0089.T000;
using R5T.T0132;
using R5T.T0143;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IAssemblyOperator : IFunctionalityMarker,
        L0066.IAssemblyOperator
	{
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0066.IAssemblyOperator _L0066 => L0066.AssemblyOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


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
            var typeOrDefault = this.Select_Types(
                assembly,
                TypeOperator.Instance.WhereNamespacedTypeNameIs(namespacedTypeName))
                .SingleOrDefault();

            var wasFound = WasFound.From(typeOrDefault);
            return wasFound;
        }
    }
}