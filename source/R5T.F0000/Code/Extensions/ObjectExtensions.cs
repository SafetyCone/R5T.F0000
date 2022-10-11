﻿using System;

using R5T.F0000;


namespace System.Extensions
{
    public static class ObjectExtensions
    {
        public static TOutput As<TInput, TOutput>(this TInput @object)
            where TOutput : class
        {
            var output = Instances.ObjectOperator.As<TInput, TOutput>(@object);
            return output;
        }

        /// <summary>
        /// Allows fluent modification of any object.
        /// </summary>
        public static T Modify<T>(this T @object,
            Action<T> modifier)
        {
            modifier(@object);

            return @object;
        }

        public static WasFound<T> WasFound<T>(this T value)
        {
            var output = R5T.F0000.WasFound.From(value);
            return output;
        }
    }
}