using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IConstructionOperator : IFunctionalityMarker
    {
        public TValue Create<TValue>(
            Func<TValue> constructor,
            params Action<TValue>[] modifiers)
        {
            var value = this.Create(
                constructor,
                modifiers.AsEnumerable());

            return value;
        }

        public TValue Create<TValue>(
            Func<TValue> constructor,
            IEnumerable<Action<TValue>> modifiers)
        {
            var value = constructor();

            ActionOperator.Instance.Run(
                value,
                modifiers);

            return value;
        }

        public async Task<TValue> Create<TValue>(
            Func<Task<TValue>> constructor,
            params Func<TValue, Task>[] modifiers)
        {
            var value = await constructor();

            await ActionOperator.Instance.Run(
                value,
                modifiers);

            return value;
        }

        public async Task<TValue> New<TValue>(
            Func<Task<TValue>> constructor,
            params Func<TValue, Task>[] modifiers)
        {
            var value = await this.Create(
                constructor,
                modifiers);

            return value;
        }
    }
}
