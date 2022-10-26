using System;

using R5T.T0142;


namespace R5T.F0000
{
    [UtilityTypeMarker]
    public class ResultOrException<T> : IEquatable<ResultOrException<T>>
    {
        #region Static

        public static implicit operator ResultOrException<T>(T result)
        {
            var output = ResultOrException.From(result);
            return output;
        }

        public static implicit operator ResultOrException<T>(Exception exception)
        {
            var output = ResultOrException.From<T>(exception);
            return output;
        }

        public static implicit operator T(ResultOrException<T> wasFound)
        {
            return wasFound.Result;
        }

        #endregion


        public Exception Exception { get; private set; }
        public bool HasResult { get; private set; }
        public T Result { get; private set; }

        public bool HasException
        {
            get
            {
                var output = Exception != null;
                return output;
            }
        }


        public ResultOrException(T result, bool hasResult, Exception exception)
        {
            Result = result;
            HasResult = hasResult;
            Exception = exception;
        }

        public ResultOrException(T result)
            : this(result, true, default)
        {
        }

        public ResultOrException(Exception exception)
            : this(default, false, exception)
        {
        }

        public override string ToString()
        {
            var hasException = HasException;

            var representation = hasException
                ? $"\n\t{Exception.Message}\n\tResult: {Result}"
                : Result.ToString()
                ;

            return representation;
        }

        public bool Equals(ResultOrException<T> other)
        {
            var output = true
                && HasResult == other.HasResult
                && Result.Equals(other.Result)
                && Exception == other.Exception
                ;

            return output;
        }
    }


    public static class ResultOrException
    {
        public static ResultOrException<T> From<T>(T result)
        {
            var output = new ResultOrException<T>(result);
            return output;
        }

        public static ResultOrException<T> From<T>(Exception exception)
        {
            var output = new ResultOrException<T>(exception);
            return output;
        }

        public static ResultOrException<T> Try<T>(Func<T> resultConstructor)
        {
            ResultOrException<T> output;

            try
            {
                var result = resultConstructor();

                output = From(result);
            }
            catch (Exception exception)
            {
                output = From<T>(exception);
            }

            return output;
        }
    }
}
