using System;
using System.Collections.Generic;
using System.Linq;

using R5T.F0000;


namespace System
{
    public static class WasFoundExtensions
    {
        public static bool AnyWereFound<T>(this IEnumerable<WasFound<T>> wasFounds)
        {
            var output = Instances.WasFoundOperator.AnyWereFound(wasFounds);
            return output;
        }

        //public static bool SingleWasFound<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByValue)
        //{
        //    var singleOrDefault = wasFoundByValue
        //        .Where(xPair => xPair.Value.Exists)
        //        .SingleOrDefault();

        //    var output = singleOrDefault != default;

        //    return output;
        //}

        public static bool AnyNotFound<T>(this IEnumerable<WasFound<T>> wasFounds)
        {
            var output = Instances.WasFoundOperator.AnyNotFound(wasFounds);
            return output;
        }

        public static WasFound<TDestination> Convert<TSource, TDestination>(this WasFound<TSource> wasFound, Func<TSource, TDestination> converterIfFound)
        {
            var output = Instances.WasFoundOperator.Convert(wasFound, converterIfFound);
            return output;
        }

        public static WasFound<TDestination> Convert<TSource, TDestination>(this WasFound<TSource> wasFound, Func<TSource, WasFound<TDestination>> converterIfFound)
        {
            var output = Instances.WasFoundOperator.Convert(wasFound, converterIfFound);
            return output;
        }

        public static void ExceptionIfNotFound<T>(this WasFound<T> wasFound, string message)
        {
            wasFound.InvalidOperationIfNotFound(message);
        }

        public static IEnumerable<TKey> GetKeysNotFound<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByValue)
        {
            var output = wasFoundByValue
                .Where(xPair => !xPair.Value.Exists)
                .Select(xPair => xPair.Key)
                ;

            return output;
        }

        public static T GetOrExceptionIfNotFound<T>(this WasFound<T> wasFound, string exceptionMessage)
        {
            wasFound.ExceptionIfNotFound(exceptionMessage);

            var output = wasFound.Result;
            return output;
        }

        public static void InvalidOperationIfNotFound<T>(this WasFound<T> wasFound, string message)
        {
            if(!wasFound)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static bool IsFound<T>(this WasFound<T> wasFound)
        {
            var output = Instances.WasFoundOperator.IsFound(wasFound);
            return output;
        }

        public static bool IsNotFound<T>(this WasFound<T> wasFound)
        {
            var output = Instances.WasFoundOperator.IsNotFound(wasFound);
            return output;
        }

        public static bool NotFound<T>(this WasFound<T> wasFound)
        {
            var output = !wasFound;
            return output;
        }

        public static WasFound<T> OrIfNotFound<T>(this WasFound<T> wasFound,
            Func<T> orIfNotFound)
        {
            var output = wasFound
                ? wasFound
                : WasFound.From(wasFound.Exists, orIfNotFound())
                ;

            return output;
        }

        public static T ResultOrDefaultIfNotFound<T>(this WasFound<T> wasFound)
        {
            var output = Instances.WasFoundOperator.ResultOrDefaultIfNotFound(wasFound);
            return output;
        }

        public static T ResultOrExceptionIfNotFound<T>(this WasFound<T> wasFound,
            Exception exception)
        {
            return Instances.WasFoundOperator.ResultOrExceptionIfNotFound(wasFound, exception);
        }

        public static T ResultOrExceptionIfNotFound<T>(this WasFound<T> wasFound,
            Func<string> exceptionMessageConstructor)
        {
            return Instances.WasFoundOperator.ResultOrExceptionIfNotFound(wasFound, exceptionMessageConstructor);
        }

        public static T ResultOrExceptionIfNotFound<T>(this WasFound<T> wasFound,
            Func<Exception> exceptionConstructor)
        {
            return Instances.WasFoundOperator.ResultOrExceptionIfNotFound(wasFound, exceptionConstructor);
        }

        public static T ResultOrExceptionIfNotFound<T, TException>(WasFound<T> wasFound,
            Func<TException> exceptionConstructor)
            where TException : Exception
        {
            return Instances.WasFoundOperator.ResultOrExceptionIfNotFound(wasFound, exceptionConstructor);
        }

        public static T ResultOrExceptionIfNotFound<T>(this WasFound<T> wasFound,
            string message)
        {
            return Instances.WasFoundOperator.ResultOrExceptionIfNotFound(wasFound,
                () => new Exception(message));
        }

        public static T ResultOrExceptionIfNotFound<T>(this WasFound<T> wasFound)
        {
            return Instances.WasFoundOperator.ResultOrExceptionIfNotFound(wasFound);
        }

        public static T Get_Result<T>(this WasFound<T> wasFound)
        {
            return Instances.WasFoundOperator.Get_Result(wasFound);
        }

        public static T ResultOrIfNotFound<T>(this WasFound<T> wasFound,
            T orIfNotFound)
        {
            var output = Instances.WasFoundOperator.ResultOrIfNotFound(
                wasFound,
                orIfNotFound);

            return output;
        }

        public static T ResultOrIfNotFound<T>(this WasFound<T> wasFound,
            Func<T> orIfNotFound)
        {
            var output = Instances.WasFoundOperator.ResultOrIfNotFound(
               wasFound,
               orIfNotFound);

            return output;
        }

        public static Dictionary<TKey, TValue> ToDictionaryFromWasFounds<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByKey)
        {
            var output = wasFoundByKey
                .ToDictionary(
                    xPair => xPair.Key,
                    xPair => xPair.Value.Result);

            return output;
        }
    }
}

namespace System.Linq
{
    public static class WasFoundExtensions
    {
        public static WasFound<T> FindSingle<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var selectionOrDefault = items
                .Where(predicate)
                .SingleOrDefault();

            var output = WasFound.From(selectionOrDefault);
            return output;
        }

        public static IEnumerable<TValue> ValuesFound<TValue>(this IEnumerable<WasFound<TValue>> wasFounds)
        {
            var output = Instances.WasFoundOperator.ValuesFound(wasFounds);
            return output;
        }

        public static IEnumerable<WasFound<T>> WhereIsFound<T>(this IEnumerable<WasFound<T>> wasFounds)
        {
            var output = Instances.WasFoundOperator.WhereIsFound(wasFounds);
            return output;
        }

        public static IEnumerable<WasFound<T>> WhereIsNotFound<T>(this IEnumerable<WasFound<T>> wasFounds)
        {
            var output = Instances.WasFoundOperator.WhereIsNotFound(wasFounds);
            return output;
        }
    }
}
