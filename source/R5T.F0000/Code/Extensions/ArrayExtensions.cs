using System;

using Instances = R5T.F0000.Instances;


namespace System
{
    public static class ArrayExtensions
    {
        public static bool IsEmpty(this Array array)
        {
            var output = Instances.ArrayOperator.IsEmpty(array);
            return output;
        }
    }
}
