using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IEnumerationOperator : IFunctionalityMarker
	{
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

        /// <summary>
        /// Gets a message indicating the the input value of the <typeparamref name="TEnum"/> enumeration was unexpected.
        /// This is useful in producing an error in the default case for switch statements based on enumeration values.
        /// </summary>
        /// <remarks>
        /// See: https://stackoverflow.com/questions/13645149/what-is-the-correct-exception-to-throw-for-unhandled-enum-values
        /// </remarks>
        public string UnexpectedEnumerationValueMessage<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var output = $@"Unexpected enumeration value: '{unexpectedValue}' for enumeration type {typeof(TEnum).FullName}";
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
    }
}