using System;
using System.Collections.Generic;

using R5T.F0000;
using R5T.T0221;

using Instances = R5T.F0000.Instances;


namespace System
{
    public static class StackExtensions
    {
        public static bool IsNotEmpty<T>(this Stack<T> stack)
        {
            var output = Instances.StackOperator.IsNotEmpty(stack);
            return output;
        }

        public static bool IsEmpty<T>(this Stack<T> stack)
        {
            var output = Instances.StackOperator.IsEmpty(stack);
            return output;
        }

        public static WasFound<T> PopOkIfEmpty<T>(this Stack<T> stack)
        {
            var output = Instances.StackOperator.PopOkIfEmpty(stack);
            return output;
        }
    }
}
