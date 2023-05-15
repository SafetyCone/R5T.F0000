using System;

using R5T.T0131;
using R5T.T0132;


namespace R5T.F0000
{
    [ValuesMarker]
    public partial interface IActions<T> : IValuesMarker, IFunctionalityMarker
    {
        public const Action<T> Null_Constant = null;

        public Action<T> DoNothing => ActionOperations.Instance.DoNothing_Synchronous;
        public Action<T> Null => null;
        public Action<T> None => ActionOperations.Instance.DoNothing_Synchronous;
    }
}
