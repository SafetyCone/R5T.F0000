using System;

using R5T.T0131;


namespace R5T.F0000
{
    [ValuesMarker]
    public partial interface ITypes : IValuesMarker
    {
        /// <summary>
        /// The C# "int" keyword refers to <see cref="System.Int32"/>.
        /// </summary>
        public Type Int => this.Int32;

        /// <summary>
        /// Type: <see cref="System.Int32"/>
        /// </summary>
        public Type Int32 => typeof(Int32);
    }
}
