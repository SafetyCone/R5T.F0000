using System;

using R5T.T0131;
using R5T.T0132;


namespace R5T.F0000
{
    [ValuesMarker]
    public partial interface IActions<T> : IValuesMarker, IFunctionalityMarker
    {
        public Action<T> DoNothing => ActionOperations.Instance.DoNothing;
        public Action<T> Null => ActionOperations.Instance.DoNothing;
        public Action<T> None => ActionOperations.Instance.DoNothing;
    }
}
