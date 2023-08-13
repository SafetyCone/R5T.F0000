using System;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IIntegerOperator : IFunctionalityMarker
    {
        public int Parse(string integer)
        {
            var output = Int32.Parse(integer);
            return output;
        }
    }
}
