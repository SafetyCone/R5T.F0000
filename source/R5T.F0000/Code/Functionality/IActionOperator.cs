using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IActionOperator : IFunctionalityMarker,
        L0053.IActionOperator
	{
        public Action<T> Combine<T>(IEnumerable<Action<T>> actions)
            => @object => actions.ForEach(action => action(@object));

        public Action<T> Combine<T>(params Action<T>[] actions)
            => this.Combine(actions.AsEnumerable());

        public Func<T, Task> Get_RunMultiple<T>(params Func<T, Task>[] actions)
        {
            return value => this.Run_OkIfDefaults(value, actions);
        }

        public async Task<TOutput> Run<T, TOutput>(
            Func<T, Task<TOutput>> action,
            T value)
        {
            if (action == default)
            {
                return default;
            }

            var output = await action(value);
            return output;
        }

        public void Run(IEnumerable<Action> actions)
        {
            if (actions == default)
            {
                return;
            }

            foreach (var action in actions)
            {
                this.Run_Action(action);
            }
        }

        public async Task Run(IEnumerable<Func<Task>> actions)
        {
            if (actions == default)
            {
                return;
            }

            foreach (var action in actions)
            {
                await this.Run(action);
            }
        }

        public async Task Run_OkIfDefaults<T>(
            T value,
            params Func<T, Task>[] actions)
		{
			foreach (var action in actions)
			{
				await this.Run_OkIfDefault(
                    value,
                    action);
			}
		}

        public async Task Run<T>(
            T value,
            IEnumerable<Func<T, Task>> actions)
        {
            foreach (var action in actions)
            {
                await this.Run_OkIfDefault(
                    value,
                    action);
            }
        }

        public async Task Run<T>(
            Func<T, Task> action,
            T value)
        {
            await this.Run_OkIfDefault(
                value,
                action);
        }

        public async Task Run<T1, T2>(
            T1 value1,
            T2 value2,
            Func<T1, T2, Task> action)
        {
            if (action == default)
            {
                return;
            }

            await action(value1, value2);
        }

        public async Task Run<T1, T2>(
            T1 value1,
            T2 value2,
            IEnumerable<Func<T1, T2, Task>> actions)
        {
            foreach (var action in actions)
            {
                await this.Run(value1, value2, action);
            }
        }
    }
}