using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ITypeNameOperator : IFunctionalityMarker
	{
		public string GetInterfaceTypeName(string typeNameStem)
		{
			var interfaceTypeName = Instances.StringOperator.PrefixWith(
				Instances.TypeNameAffixes.InterfacePrefix,
				typeNameStem);

			return interfaceTypeName;
		}

		public string GetTypeNameOf<T>(T instance)
        {
			var output = Instances.TypeOperator.GetTypeNameOf(instance);
			return output;
        }
	}
}