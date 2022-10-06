using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ITypeOperator : IFunctionalityMarker
	{
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
			var output = type.FullName;
			return output;
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
	}
}