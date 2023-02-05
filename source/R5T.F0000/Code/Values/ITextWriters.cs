using System;
using System.IO;

using R5T.T0131;


namespace R5T.F0000
{
    [ValuesMarker]
    public partial interface ITextWriters : IValuesMarker
    {
        public TextWriter Console => System.Console.Out;
    }
}
