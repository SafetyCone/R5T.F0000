using System;
using System.Collections.Generic;
using System.Linq;

using R5T.F0000;
using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
	public partial interface IWasFoundOperator : IFunctionalityMarker
	{
        public bool AnyNotFound<T>(IEnumerable<WasFound<T>> wasFounds)
        {
            var output = wasFounds
                .Select(x => x.IsNotFound())
                .Any();

            return output;
        }

        public bool AnyWereFound<T>(IEnumerable<WasFound<T>> wasFounds)
        {
            var output = wasFounds
                .WhereIsFound()
                .Any();

            return output;
        }

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

        public WasFound<TDestination> Convert<TSource, TDestination>(WasFound<TSource> wasFound, Func<TSource, WasFound<TDestination>> converterIfFound)
        {
            if (wasFound)
            {
                var convertedResult = converterIfFound(wasFound.Result);

                var output = convertedResult;
                return output;
            }
            else
            {
                var output = WasFound.From(wasFound, default(TDestination));
                return output;
            }
        }

        public bool IsFound<T>(WasFound<T> wasFound)
        {
            return wasFound.Exists;
        }

        public bool IsNotFound<T>(WasFound<T> wasFound)
        {
            var output = !wasFound.Exists;
            return output;
        }

        public T ResultOrDefaultIfNotFound<T>(WasFound<T> wasFound)
        {
            var output = wasFound
                ? wasFound.Result
                : default
                ;

            return output;
        }

        public T ResultOrExceptionIfNotFound<T>(WasFound<T> wasFound,
            Exception exception)
        {
            if(!wasFound)
            {
                throw exception;
            }

            return wasFound.Result;
        }

        public T ResultOrExceptionIfNotFound<T>(WasFound<T> wasFound,
            Func<Exception> exceptionConstructor)
        {
            if (!wasFound)
            {
                var exception = exceptionConstructor();
                throw exception;
            }

            return wasFound.Result;
        }

        public T ResultOrExceptionIfNotFound<T, TException>(WasFound<T> wasFound,
            Func<TException> exceptionConstructor)
            where TException : Exception
        {
            if (!wasFound)
            {
                var exception = exceptionConstructor();
                throw exception;
            }

            return wasFound.Result;
        }

        public T ResultOrExceptionIfNotFound<T>(WasFound<T> wasFound,
            string message)
        {
            var output = this.ResultOrExceptionIfNotFound(wasFound,
                () => new Exception(message));

            return output;
        }

        public T ResultOrExceptionIfNotFound<T>(WasFound<T> wasFound)
        {
            var output = this.ResultOrExceptionIfNotFound(wasFound,
                () => new Exception("Result did not exist."));

            return output;
        }

        public T Get_Result<T>(WasFound<T> wasFound)
        {
            return this.ResultOrExceptionIfNotFound(wasFound);
        }

        public T ResultOrIfNotFound<T>(
            WasFound<T> wasFound,
            T orIfNotFound)
        {
            var output = wasFound
                ? wasFound.Result
                : orIfNotFound
                ;

            return output;
        }

        public T ResultOrIfNotFound<T>(
            WasFound<T> wasFound,
            Func<T> orIfNotFound)
        {
            var output = wasFound
                ? wasFound.Result
                : orIfNotFound()
                ;

            return output;
        }

        public IEnumerable<TValue> ValuesFound<TValue>(IEnumerable<WasFound<TValue>> wasFounds)
        {
            var output = wasFounds
                .WhereIsFound()
                .Select(wasFound => wasFound.Result)
                ;

            return output;
        }

        public IEnumerable<WasFound<T>> WhereIsNotFound<T>(IEnumerable<WasFound<T>> wasFounds)
        {
            var output = wasFounds
                .Where(x => x.IsNotFound())
                ;

            return output;
        }

        public IEnumerable<WasFound<T>> WhereIsFound<T>(IEnumerable<WasFound<T>> wasFounds)
        {
            var output = wasFounds
                .Where(x => x.IsFound())
                ;

            return output;
        }
    }
}