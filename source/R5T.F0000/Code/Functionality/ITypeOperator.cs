using System;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ITypeOperator : IFunctionalityMarker
	{
		public string GetNamespaceName(Type type)
        {
			var namespaceName = type.Namespace;
			return namespaceName;
        }

		public string GetTypeName(Type type)
        {
			var typeName = type.Name;
			return typeName;
        }

		public string GetNamespacedTypeName<T>()
        {
			var typeOfT = typeof(T);

			var output = this.GetNamespacedTypeName(typeOfT);
			return output;
        }

		/// <summary>
		/// Quality-of-life overload for <see cref="GetNamespacedTypeName(Type)"/>.
		/// </summary>
		public string GetNamespacedTypeName_ForType(Type type)
        {
			return this.GetNamespacedTypeName(type);
        }

		public string GetNamespacedTypeName(Type type)
		{
			var namespaceName = this.GetNamespaceName(type);
			var typeName = this.GetTypeName(type);

			var namespacedTypeName = Instances.NamespacedTypeNameOperator.GetNamespacedTypeName(
				namespaceName,
				typeName);

			return namespacedTypeName;
		}

		public string GetNamespacedTypeName(TypeInfo typeInfo)
		{
			var output = this.GetNamespacedTypeName(typeInfo as Type);
			return output;
		}

		/// <summary>
		/// Quality-of-life overload for <see cref="GetNamespacedTypeName(TypeInfo)"/>.
		/// </summary>
		public string GetNamespacedTypeName_ForTypeInfo(TypeInfo typeInfo)
		{
			return this.GetNamespacedTypeName(typeInfo);
		}

		public string GetNameOf<T>()
        {
			var type = this.GetTypeOf<T>();

			var output = this.GetNameOf(type);
			return output;
        }

		public string GetNameOf(Type type)
        {
			var output = type.Name;
			return output;
        }

		public string GetTypeNameOf<T>(T instance)
        {
			var type = this.GetTypeOf(instance);

			var output = this.GetNameOf(type);
			return output;
        }

		/// <summary>
		/// Gets the type of the <typeparamref name="T"/>.
		/// Note: same as the typeof() operator.
		/// </summary>
		public Type GetTypeOf<T>()
        {
			var output = typeof(T);
			return output;
        }

		public Type GetTypeOf<T>(T instance)
        {
			var output = instance.GetType();
			return output;
        }

		/// <summary>
		/// Gets the parameters of the type, whether or not they have values.
		/// </summary>
		public Type[] GetGenericTypeParameters(Type type)
        {
			var genericTypeParameters = type.GetGenericArguments();
			return genericTypeParameters;
        }

		/// <summary>
		/// Gets the parameter values (arguments) of the type.
		/// Note: It is possible to fill in an unspecified type parameter!
		/// </summary>
		public Type[] GetGenericTypeParameterValues(Type type)
		{
			var genericTypeParameters = type.GenericTypeArguments;
			return genericTypeParameters;
		}

		public bool IsGeneric(Type type)
        {
			var isGeneric = type.IsGenericType;
			return isGeneric;
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

			var method = WasFoundOperator.Instance.ResultOrExceptionIfNotFound(
				hasMethod,
				$"{methodName}: method with name not found on type '{this.GetNamespacedTypeName(typeInfo)}'.");

			return method;
        }

        /// <summary>
        /// <inheritdoc cref = "Y0000.Glossary.ForType.ClosedGeneric" path="/definition"/>
        /// </summary>
        public bool IsClosedGeneric(Type type)
		{
			// If the type is not at least a constructed generic type, then it cannot be a closed generic type.
			// This test will determine closed/open for all generic types with only a single type parameter: if any construction has been done to the definition, and there is only a single parameter, then the single paramter has been filled-in, meaning all parameters have been filled-in.
			var isConstructed = this.IsConstructedGeneric(type);
			if(!isConstructed)
            {
				return false;
            }

			// Now test all type parameters to see if they are specified.
			var genericTypeParameterValues = this.GetGenericTypeParameterValues(type);

			var unspecifiedGenericTypeParameterValues = genericTypeParameterValues
				.Where(xTypeParameterValue => this.IsUnspecifiedGenericTypeParameterValue(xTypeParameterValue))
				;

			var anyUnspecifiedGenericTypeParameterValues = unspecifiedGenericTypeParameterValues.Any();

			var isClosed = !anyUnspecifiedGenericTypeParameterValues;
			return isClosed;
		}

        public bool IsUnspecifiedGenericTypeParameterValue(Type type)
        {
			var output = type.IsGenericTypeParameter;
			return output;
        }

        /// <summary>
        /// <inheritdoc cref = "Y0000.Glossary.ForType.ConstructedGeneric" path="/definition"/>
        /// </summary>
        public bool IsConstructedGeneric(Type type)
		{
			var isConstructed = type.IsConstructedGenericType;
			return isConstructed;
		}

		/// <summary>
		/// <inheritdoc cref = "Y0000.Glossary.ForType.GenericDefinition" path="/definition"/>
		/// </summary>
		public bool IsGenericDefinition(Type type)
		{
			var isGeneric = type.IsGenericTypeDefinition;
			return isGeneric;
		}

		public bool Is_Int32(Type type)
		{
			var output = type == Instances.Types.Int32;
			return output;
		}

		/// <summary>
		/// <inheritdoc cref = "Y0000.Glossary.ForType.OpenGeneric" path="/definition"/>
		/// </summary>
		public bool IsOpenGeneric(Type type)
		{

			var isOpen = type.IsGenericTypeDefinition;
			return isOpen;
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