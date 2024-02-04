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
	public partial interface ITypeNameOperator : IFunctionalityMarker,
        L0053.ITypeNameOperator
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

        /// <summary>
        /// Ensures the first letter of the type name is capitalized.
        /// </summary>
        public string Ensure_IsCapitalized(
            string typeName)
        {
            var output = Instances.TextOperator.Ensure_IsCapitalized(typeName);
            return output;
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
                var output = this.Get_NonAttributeSuffixedTypeName(typeName);
                return output;
            }
            else
            {
                return typeName;
            }
        }

        /// <summary>
        /// Retursn the type name stem for a type name of either an interface or a class.
        /// Determines if the type interface-indicated, and if so, handles it.
        /// Otherwise if the type is not interface-indicated, it is assumed to be a class name, which is also handled.
        /// </summary>
        public string GetTypeNameStem_HandleInterface(string typeName)
        {
            var isInterfaceIndicated = this.Is_InterfaceIndicatedTypeName(typeName);

            var typeNameStem = isInterfaceIndicated
                // No need to check whether the type is interface-indicated since we have already done that.
                ? Internal.GetTypeNameStemForInterfaceName_Unchecked(typeName)
                // If not interface-indicated, then the type is assumed to be a class name.
                // The type name stem of a class name is just the class name.
                : typeName
                ;

            return typeNameStem;
        }

        /// <inheritdoc cref="Internal.ITypeNameOperator.GetTypeNameStemForInterfaceName_Unchecked(string)"/>
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

        public bool Is_InterfaceTypeName(string typeName)
        {
            var output = this.Is_InterfaceIndicatedTypeName(typeName);
            return output;
        }

        /// <summary>
        /// Determines if a type name is interface-indicated, which is:
        /// 1. The length is at least two characters.
        /// 2. Starts with an 'I'
        /// 3. The second letter is also capitalized, like "IEnumerable" for example would be.
        /// </summary>
        public bool Is_InterfaceIndicatedTypeName(string typeName)
        {
            // Must not be empty.
            var isEmpty = StringOperator.Instance.Is_Empty(typeName);
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
            var isEmpty = StringOperator.Instance.Is_Empty(typeName);
            if (isEmpty)
            {
                return false;
            }

            // 1) Is the first character of the type name capitalized?
            var firstCharacter = typeName.Second();
            var firstCharacterIsCapitalized = CharacterOperator.Instance.Is_Capitalized(firstCharacter);

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
            var isEmpty = StringOperator.Instance.Is_Empty(typeNameValue);
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
        /// <summary>
        /// Removes the first letter of the interface type name to get the type name stem.
        /// For example, the type name stem of "IEnumerable" would be "Enumerable".
        /// </summary>
        public string GetTypeNameStemForInterfaceName_Unchecked(string interfaceTypeName)
        {
            var output = Instances.StringOperator_Internal.Except_First_Unchecked(interfaceTypeName);
            return output;
        }
    }
}