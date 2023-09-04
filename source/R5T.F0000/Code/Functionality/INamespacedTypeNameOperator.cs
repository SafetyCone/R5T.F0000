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
			if(tokens.Length < 1)
			{
				return Instances.Strings.Empty;
			}

			if(tokens.Length < 2)
			{
				return tokens.First();
			}

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
			if(Instances.StringOperator.IsNullOrEmpty(namespaceName))
			{
				return typeName;
			}

			var namespacedTypeName = this.Combine(namespaceName, typeName);
			return namespacedTypeName;
		}

		/// <summary>
		/// Handles generic type names.
		/// </summary>
		public string GetNamespacedTypeName_FromFullName(string fullTypeName)
		{
			var parts = fullTypeName.Split(
				Instances.Characters.OpenBracket_Correct);

			var namespacedTypeName = parts.First();
			return namespacedTypeName;
		}

		/// <summary>
		/// Note: Can handle types in the global namespace (those where the namespaced type name is just the type name).
		/// </summary>
		public string GetNamespaceName(string namespacedTypeName)
        {
			var tokenSeparatorChar = this.GetTokenSeparator_Character();

			var lastTokenSeparatorIndex = namespacedTypeName.LastIndexOf(tokenSeparatorChar);
			if(Instances.IndexOperator.Is_Found(lastTokenSeparatorIndex))
			{
                var namespaceName = namespacedTypeName[..(lastTokenSeparatorIndex)];
                return namespaceName;
            }
			else
			{
				// There is no namespace name, just a type name, indicating the type is in the global namespace.
				return Instances.Strings.Empty;
			}
        }

        /// <summary>
        /// Note: Can handle types in the global namespace (those where the namespaced type name is just the type name).
        /// </summary>
        public string GetTypeName(string namespacedTypeName)
        {
			var nameparts = this.GetNameParts(namespacedTypeName);

			var typeName = nameparts.Last();
			return typeName;
        }
	}
}