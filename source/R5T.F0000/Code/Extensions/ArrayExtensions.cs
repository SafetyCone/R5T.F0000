using System;

using Instances = R5T.F0000.Instances;


namespace System
{
    public static class ArrayExtensions
    {
        public static bool Is_Empty(this Array array)
        {
            var output = Instances.ArrayOperator.Is_Empty(array);
            return output;
        }
    }
}
