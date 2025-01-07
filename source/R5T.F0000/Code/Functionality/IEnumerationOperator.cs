using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IEnumerationOperator : IFunctionalityMarker,
        L0053.IEnumerationOperator
	{
        private static Unchecked.IEnumerationOperator Unchecked => F0000.Unchecked.EnumerationOperator.Instance;


        public TEnum From_Int32<TEnum>(int value)
            where TEnum : Enum
        {
            this.Verify_IsInt32Based<TEnum>();

            var output = Unchecked.From_Int32<TEnum>(value);
            return output;
        }

        public string GetStringRepresentation<TEnum>(TEnum @enum)
			where TEnum : Enum
        {
			var output = @enum.ToString();
			return output;
        }

        public TEnum GetValue<TEnum>(string valueString)
            where TEnum : Enum
        {
            var value = (TEnum)Enum.Parse(typeof(TEnum), valueString);
            return value;
        }

        public bool Is_Int32Based(Enum value)
        {
            var enumerationType = value.GetType();

            var output = this.Is_Int32Based(enumerationType);
            return output;
        }

        public bool Is_Int32Based<TEnum>()
            where TEnum : Enum
        {
            var enumerationType = typeof(TEnum);

            var output = this.Is_Int32Based(enumerationType);
            return output;
        }

        public bool Is_Int32Based(Type enumerationType)
        {
            var underlyingType = Enum.GetUnderlyingType(enumerationType);

            var output = Instances.TypeOperator.Is_Int32(underlyingType);
            return output;
        }

        /// <summary>
        /// Produces an exception for use in the default case of a switch statement based on values of the <typeparamref name="TEnum"/> enumeration.
        /// Note: there is no method just throwing the exception, as the VS linter does not detect that a method call will always produce an exception, and thus demands that switch default case behavior cannot fall through one default case to another. The throw keyword in the switch default case must be present.
        /// </summary>
        public UnexpectedEnumerationValueException<TEnum> SwitchDefaultCaseException<TEnum>(TEnum value)
            where TEnum : Enum
        {
            var exception = this.UnexpectedEnumerationValueException(value);
            return exception;
        }

        public int To_Int32(Enum value)
        {
            this.Verify_IsInt32Based(value);

            var output = Unchecked.To_Int32(value);
            return output;
        }

        /// <summary>
        /// Produces an exception for the situation where a value of the <typeparamref name="TEnum"/> enumeration was unexpected.
        /// This is useful in producing an error in the default case for switch statements based on enumeration values.
        /// </summary>
        public UnexpectedEnumerationValueException<TEnum> UnexpectedEnumerationValueException<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var unexpectedEnumerationValueException = new UnexpectedEnumerationValueException<TEnum>(unexpectedValue);
            return unexpectedEnumerationValueException;
        }

        public void Verify_IsInt32Based(Enum value)
        {
            var enumerationType = value.GetType();

            this.Verify_IsInt32Based(enumerationType);
        }

        public void Verify_IsInt32Based<TEnum>()
            where TEnum : Enum
        {
            var enumerationType = typeof(TEnum);

            this.Verify_IsInt32Based(enumerationType);
        }

        public void Verify_IsInt32Based(Type enumerationType)
        {
            var isInt32Based = this.Is_Int32Based(enumerationType);
            if(!isInt32Based)
            {
                throw new Exception("Enumeration type was not based on the 32-bit integer type.");
            }
        }
    }
}