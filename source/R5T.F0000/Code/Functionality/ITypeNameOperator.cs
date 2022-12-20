using System;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
    /// <summary>
    /// TODO:
    ///     * Process R5T.B0001.X001
    /// </summary>
	[FunctionalityMarker]
	public partial interface ITypeNameOperator : IFunctionalityMarker
	{
        private static Internal.ITypeNameOperator Internal => F0000.Internal.TypeNameOperator.Instance;


        public string AddSuffix(
            string typeName,
            string suffix)
        {
            var output = Instances.StringOperator.Suffix(
                typeName,
                suffix);

            return output;
        }

        public string GetAttributeNameFromAttributeTypeName(
            string attributeTypeName)
        {
            var hasAttributeTypeNameSuffix = this.HasAttributeTypeNameSuffix(attributeTypeName);
            if (hasAttributeTypeNameSuffix)
            {
                var output = this.GetNonAttributeSuffixedTypeName(attributeTypeName);
                return output;
            }
            else
            {
                throw new ArgumentException($"Attribute type name '{attributeTypeName}' did not have attribute suffix.");
            }
        }

        public string GetAttributeSuffixedTypeName(string typeName)
        {
            var output = Instances.StringOperator.Suffix(
                typeName,
                TypeNameAffixes.Instance.AttributeSuffix);

            return output;
        }

        public string GetClassTypeName(string typeNameStem)
		{
            // The class type name is the same as the type name stem.
			var classTypeName = typeNameStem;
            return classTypeName;
        }

		public string GetExtensionsOfTypeNameTypeName(string typeName)
		{
            var extensionsTypeName = $"{typeName}{TypeNameAffixes.Instance.ExtensionsSuffix}";
            return extensionsTypeName;
        }

        public string GetDefaultImplementationClassTypeNameForInterface(string interfaceTypeName)
        {
            var typeNameStem = this.GetTypeNameStemForInterfaceName(interfaceTypeName);

            var output = this.GetClassTypeName(typeNameStem);
            return output;
        }

        public string GetEnsuredAttributeSuffixedTypeName(string typeName)
        {
            var isAttributeSuffixedTypeName = this.Is_AttributeSuffixedTypeName(typeName);
            if (isAttributeSuffixedTypeName)
            {
                return typeName;
            }
            else
            {
                var output = this.GetAttributeSuffixedTypeName(typeName);
                return output;
            }
        }

        public string GetEnsuredNonAttributeSuffixedTypeName(string typeName)
        {
            var isAttributeSuffixedTypeName = this.Is_AttributeSuffixedTypeName(typeName);
            if (isAttributeSuffixedTypeName)
            {
                var output = this.GetNonAttributeSuffixedTypeName(typeName);
                return output;
            }
            else
            {
                return typeName;
            }
        }

        public string GetNonAttributeSuffixedTypeName(string attributeSuffixedTypeName)
        {
            var output = Instances.StringOperator.ExceptEnding(
                attributeSuffixedTypeName,
                TypeNameAffixes.Instance.AttributeSuffix);

            return output;
        }

        public string GetTypeNameStemForInterfaceName(string interfaceTypeName)
        {
            // Verify the input is an interface name.
            this.Verify_IsInterfaceTypeName(interfaceTypeName);

            var output = Internal.GetTypeNameStemForInterfaceName_Unchecked(interfaceTypeName);
            return output;
        }

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

        /// <summary>
        /// Quality-of-life overload for <see cref="Is_AttributeSuffixedTypeName(string)"/>.
        /// </summary>
        public bool HasAttributeTypeNameSuffix(string typeName)
        {
            var output = this.Is_AttributeSuffixedTypeName(typeName);
            return output;
        }

        public bool Is_AttributeSuffixedTypeName(string typeName)
        {
            var output = Instances.StringOperator.EndsWith(
                typeName,
                TypeNameAffixes.Instance.AttributeSuffix);

            return output;
        }

        public bool Is_InterfaceTypeName(string typeName)
        {
            // Must not be empty.
            var isEmpty = StringOperator.Instance.IsEmpty(typeName);
            if(isEmpty)
            {
                return false;
            }

            // 1) Is the name at least two characters long?
            var lengthAtLeastTwo = typeName.Length > 1;

            // 2) Is the first character of the type name the interface name prefix character?
            var firstCharacterIsInterfaceNamePrefix = typeName.First() == TypeNameAffixes.Instance.InterfacePrefix_Character;

            // 3) Is the second character also capitalized (allowing for ImageData to be a class, while IImageData would be an interface)?
            var secondCharacter = typeName.Second();
            var secondCharacterIsAlsoCapitalized = Char.IsUpper(secondCharacter);

            var output = true
                && lengthAtLeastTwo
                && firstCharacterIsInterfaceNamePrefix
                && secondCharacterIsAlsoCapitalized
                ;

            return output;
        }

        public bool Is_TypeName(string typeName)
        {
            // Must not be empty.
            var isEmpty = StringOperator.Instance.IsEmpty(typeName);
            if (isEmpty)
            {
                return false;
            }

            // 1) Is the first character of the type name capitalized?
            var firstCharacter = typeName.Second();
            var firstCharacterIsCapitalized = CharacterOperator.Instance.IsCapitalized(firstCharacter);

            var output = true
                && firstCharacterIsCapitalized
                ;

            return output;
        }

        public string Pluralize(string typeName)
        {
            this.Verify_IsTypeName(typeName);

            var output = StringOperator.Instance.Append(typeName, Instances.Strings.s_Lowercase);
            return output;
        }

        public void Verify_IsNotEmpty(string typeNameValue)
        {
            var isEmpty = StringOperator.Instance.IsEmpty(typeNameValue);
            if (isEmpty)
            {
                throw new ArgumentException(
                    ExceptionMessages.Instance.TypeNameValueWasEmpty,
                    nameof(typeNameValue));
            }
        }

        public void Verify_IsInterfaceTypeName(string interfaceTypeName)
        {
            var isInterface = this.Is_InterfaceTypeName(interfaceTypeName);
            if (!isInterface)
            {
                throw new Exception($"'{interfaceTypeName}': Type name not recognized as an interface type name.");
            }
        }

        public void Verify_IsTypeName(string typeName)
        {
            var isTypeName = this.Is_TypeName(typeName);
            if (!isTypeName)
            {
                throw new Exception($"'{typeName}': String not recognized as a type name.");
            }
        }
    }
}


namespace R5T.F0000.Internal
{
    [FunctionalityMarker]
    public partial interface ITypeNameOperator : IFunctionalityMarker
	{
        public string GetTypeNameStemForInterfaceName_Unchecked(string interfaceTypeName)
        {
            var output = StringOperator.Instance.ExceptFirst_Unchecked(interfaceTypeName);
            return output;
        }
    }
}