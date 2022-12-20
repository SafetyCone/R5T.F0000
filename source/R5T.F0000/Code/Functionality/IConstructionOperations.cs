using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IConstructionOperations : IFunctionalityMarker
    {
        public Func<Task<TValue>> New<TValue>(
            Func<Task<TValue>> constructor,
            params Func<TValue, Task>[] modifiers)
        {
            return () => ConstructionOperator.Instance.New(
                constructor,
                modifiers);
        }
    }
}
