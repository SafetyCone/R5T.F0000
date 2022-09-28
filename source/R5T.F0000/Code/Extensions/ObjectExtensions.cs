using System;


namespace System.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Allows fluent modification of any object.
        /// </summary>
        public static T Modify<T>(this T @object,
            Action<T> modifier)
        {
            modifier(@object);

            return @object;
        }
    }
}
