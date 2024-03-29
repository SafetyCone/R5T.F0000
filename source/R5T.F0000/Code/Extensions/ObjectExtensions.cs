﻿using System;
using System.Collections.Generic;

using R5T.F0000;
using R5T.L0089.T000;

using Instances = R5T.F0000.Instances;


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

        public static T ModifyIf<T>(this T @object,
            bool condition,
            Action<T> modifyAction)
        {
            ObjectOperator.Instance.ModifyIf(
                @object,
                condition,
                modifyAction);

            return @object;
        }

        public static WasFound<T> WasFound<T>(this T value)
        {
            var output = R5T.L0089.T000.WasFound.From(value);
            return output;
        }
    }
}


namespace R5T.F0000.ArrayExtensions
{
    /// <inheritdoc cref="R5T.F0000.Extensions.ForObject.ObjectExtensions"/>
    public static class ObjectExtensions
    {
        public static T[] ToArray<T>(this T value)
        {
            return Instances.ArrayOperator.From(value);
        }
    }
}

namespace R5T.F0000.Extensions.ForObject
{
    /// <summary>
    /// A special namespace is used since object-extensions are dangerous since they are likely to pollute the intellisense of every variable.
    /// </summary>
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

        /// <summary>
        /// Allows fluently changing an object to another instance of the same type.
        /// </summary>
        public static T Change<T>(this T @object,
            Func<T, T> changer)
        {
            var output = changer(@object);

            return output;
        }

        public static T ModifyIf<T>(this T @object,
            bool condition,
            Action<T> modifyAction)
        {
            ObjectOperator.Instance.ModifyIf(
                @object,
                condition,
                modifyAction);

            return @object;
        }

        public static WasFound<T> WasFound<T>(this T value)
        {
            var output = R5T.L0089.T000.WasFound.From(value);
            return output;
        }
    }
}


namespace System.Linq
{
    public static class ObjectExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this T instance)
        {
            yield return instance;
        }
    }
}