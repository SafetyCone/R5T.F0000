using System;
using System.Collections.Generic;
using System.Text;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IStringBuilderOperator : IFunctionalityMarker
    {
        public StringBuilder AppendLines(StringBuilder stringBuilder, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                stringBuilder.AppendLine(line);
            }

            return stringBuilder;
        }
    }
}
