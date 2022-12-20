using System;
using System.IO;
using System.Text;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IStringStreamOperator : IFunctionalityMarker
    {
        public Stream From(string @string)
        {
            var memoryStream = new MemoryStream(
                Encoding.UTF8.GetBytes(@string));

            return memoryStream;
        }
    }
}
