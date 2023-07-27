using System;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface INullOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Returns whether a null check can decide whether two instances are equal,
        /// and if so, what equality the null check provides.
        /// </summary>
        public bool NullCheckDeterminesEquality<T>(T a, T b, out bool areEqual)
            // Restrict to reference types so that we don't accidentally use this on value types (since the "is null" syntax works for value types, this operation is unneccesary).
            where T : class
        {
            if (a is null)
            {
                if (b is null)
                {
                    // If both are null, then a null check can determine equality, and both are equal.
                    areEqual = true;
                    return true;
                }
                else
                {
                    // If one is null, but the other is not, then a null check can determine equality, and both are equal.
                    areEqual = false;
                    return true;
                }
            }
            else
            {
                if (b is null)
                {
                    // If one is null, but the other is not, then a null check can determine equality, and both are equal.
                    areEqual = false;
                    return true;
                }
                else
                {
                    // If neither are null, then a null check *cannot* determine equality. Return a dummy value for if they are equal.
                    areEqual = false;
                    return false;
                }
            }
        }

        public bool Is_NotNull<T>(T value)
            where T : class
        {
            // A great, quick null check.
            var output = value is object;
            return output;
        }

        public bool Is_Null<T>(T value)
            where T : class
        {
            var output = value is null;
            return output;
        }
    }
}
