using System;

using R5T.T0142;


namespace R5T.F0000
{
    /// <summary>
    /// Struct is chosen so that users never have to remember to initialize objects of this type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [UtilityTypeMarker]
    public struct IsSet<T>
    {
        private T zValue;
        public T Value
        {
            readonly get => this.zValue;
            set
            {
                this.WasSet = true;

                this.zValue = value;
            }
        }

        public bool WasSet { get; private set; }


        public IsSet(T value)
        {
            this.zValue = value;

            this.WasSet = true;
        }
    }

    public static class IsSet
    {
        public static IsSet<T> Set<T>(T value)
        {
            return new IsSet<T>(value);
        }
    }
}
