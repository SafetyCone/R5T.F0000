using System;
using System.Text;

using Instances = R5T.F0000.Instances;


namespace System
{
    public static class StringBuilderExtensions
    {
        public static string GetString(this StringBuilder stringBuilder, Action<StringBuilder> modifier)
        {
            var output = Instances.StringOperator.GetString(stringBuilder, modifier);
            return output;
        }
    }
}
