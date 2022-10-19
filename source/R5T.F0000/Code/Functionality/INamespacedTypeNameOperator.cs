using System;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface INamespacedTypeNameOperator : IFunctionalityMarker
	{
		public string Combine(params string[] tokens)
        {
			var tokenSeparator = this.GetTokenSeparator();

			var output = Instances.StringOperator.Join(
				tokenSeparator,
				tokens);

			return output;
		}

		public string GetTokenSeparator_String()
        {
			var output = Instances.Strings.Period;
			return output;
        }

		public char GetTokenSeparator_Character()
		{
			var output = Instances.Characters.Period;
			return output;
		}

		/// <summary>
		/// Chooses character as the default token separator type.
		/// </summary>
		public char GetTokenSeparator()
		{
			var output = this.GetTokenSeparator_Character();
			return output;
		}

		public string[] GetNameParts(string namespacedTypeName)
        {
			var tokenSeparator = this.GetTokenSeparator();

			var output = namespacedTypeName.Split(tokenSeparator);
			return output;
        }

		public string GetNamespacedTypeName(
			string namespaceName,
			string typeName)
        {
			var namespacedTypeName = this.Combine(namespaceName, typeName);
			return namespacedTypeName;
		}

		/// <summary>
		/// Handles generic type names.
		/// </summary>
		public string GetNamespacedTypeName_FromFullName(string fullTypeName)
		{
			var parts = fullTypeName.Split(
				Instances.Characters.OpenBrace);

			var namespacedTypeName = parts.First();
			return namespacedTypeName;
		}

		public string GetNamespaceName(string namespacedTypeName)
        {
			var tokenSeparatorChar = this.GetTokenSeparator_Character();

			var lastTokenSeparatorIndex = namespacedTypeName.LastIndexOf(tokenSeparatorChar);

			var namespaceName = namespacedTypeName[..(lastTokenSeparatorIndex)];
			return namespaceName;
        }

		public string GetTypeName(string namespacedTypeName)
        {
			var nameparts = this.GetNameParts(namespacedTypeName);

			var typeName = nameparts.Last();
			return typeName;
        }
	}
}