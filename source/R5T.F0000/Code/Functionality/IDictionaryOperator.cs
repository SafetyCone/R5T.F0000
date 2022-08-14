using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IDictionaryOperator : IFunctionalityMarker
	{
        public string GetKeyNotFoundExceptionMessage(string key)
        {
            var message = $"Key not found: '{key}'";
            return message;
        }

        public KeyNotFoundException GetKeyNotFoundException(string key)
        {
            var message = this.GetKeyNotFoundExceptionMessage(key);

            var exception = new KeyNotFoundException(message);
            return exception;
        }
    }
}