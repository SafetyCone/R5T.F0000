using System;
using System.Linq;
using System.Reflection;

using R5T.L0089.T000;
using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ITypeOperator : IFunctionalityMarker,
		L0053.ITypeOperator
	{
		public string GetNameOf<T>()
        {
			var type = this.Get_TypeOf<T>();

			var output = this.GetNameOf(type);
			return output;
        }

		public string GetNameOf(Type type)
        {
			var output = type.Name;
			return output;
        }

		public WasFound<MethodInfo> HasMethod_Declarared(
			TypeInfo typeInfo,
			string methodName)
		{
			var methodOrDefault = typeInfo.DeclaredMethods
				.Where(method => method.Name == methodName)
				.SingleOrDefault();

			var wasFound = WasFound.From(methodOrDefault);
			return wasFound;
		}

        public MethodInfo GetMethod_Declarared(
            TypeInfo typeInfo,
            string methodName)
        {
			var hasMethod = this.HasMethod_Declarared(
				typeInfo,
				methodName);

			var method = Instances.WasFoundOperator.Get_Result_OrExceptionIfNotFound(
				hasMethod,
				$"{methodName}: method with name not found on type '{this.Get_NamespacedTypeName(typeInfo)}'.");

			return method;
        }

		public bool Is_Int32(Type type)
		{
			var output = type == Instances.Types.Int32;
			return output;
		}

		/// <summary>
		/// A type is a class, interface, struct, enum, or delegate.
		/// </summary>
		public bool IsType(Type type)
		{
			var output = type.IsTypeDefinition;
			return output;
		}

        public Func<TypeInfo, bool> WhereNamespacedTypeNameIs(string namespacedTypeName)
		{
			return typeInfo =>
			{
				var namespacedTypeNameForTypeInfo = this.GetNamespacedTypeName_ForTypeInfo(typeInfo);

				var output = namespacedTypeNameForTypeInfo == namespacedTypeName;
				return output;
            };
		}
	}
}