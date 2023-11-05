using System;
using System.Collections.Generic;

using R5T.N0000;
using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
	public partial interface IStackOperator : IFunctionalityMarker
	{
        public bool IsNotEmpty<T>(Stack<T> stack)
        {
            var output = stack.Count > 0;
            return output;
        }

        public bool IsEmpty<T>(Stack<T> stack)
        {
            var output = stack.Count < 1;
            return output;
        }

        public WasFound<T> PopOkIfEmpty<T>(Stack<T> stack)
        {
            var isNotEmpty = stack.IsNotEmpty();

            var value = isNotEmpty
                ? stack.Pop()
                : default
                ;

            var output = WasFound.From(isNotEmpty, value);
            return output;
        }
    }
}