using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IWasFoundOperator : IFunctionalityMarker
	{
        public WasFound<TDestination> Convert<TSource, TDestination>(WasFound<TSource> wasFound, Func<TSource, TDestination> converterIfFound)
        {
            if (wasFound)
            {
                var convertedResult = converterIfFound(wasFound.Result);

                var output = WasFound.From(wasFound, convertedResult);
                return output;
            }
            else
            {
                var output = WasFound.From(wasFound, default(TDestination));
                return output;
            }
        }
    }
}