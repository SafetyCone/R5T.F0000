using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IActionOperator : IFunctionalityMarker
	{
		public Func<T, Task> Get_RunMultiple<T>(params Func<T, Task>[] actions)
		{
			return value => this.Run_OkIfDefaults(value, actions);
		}

		public async Task Run_OkIfDefaults<T>(T value, params Func<T, Task>[] actions)
		{
			foreach (var action in actions)
			{
				await this.Run_OkIfDefault(
					action,
					value);
			}
		}

        public async Task Run<T>(T value, params Func<T, Task>[] actions)
		{
			await this.Run_OkIfDefaults(value, actions);
		}

        public async Task Run_OkIfDefault<T>(Func<T, Task> action, T value)
        {
            if (action == default)
            {
                return;
            }

            await action(value);
        }

        /// <summary>
        /// Chooses <see cref="Run_OkIfDefault{T}(Action{T}, T)"/> as the default.
        /// </summary>
        public async Task Run<T>(Func<T, Task> action, T value)
        {
            await this.Run_OkIfDefault(action, value);
        }

        public void Run_OkIfDefault<T>(Action<T> action, T value)
		{
			if(action == default)
			{
				return;
			}

			action(value);
		}

		/// <summary>
		/// Chooses <see cref="Run_OkIfDefault{T}(Action{T}, T)"/> as the default.
		/// </summary>
		public void Run<T>(Action<T> action, T value)
		{
			this.Run_OkIfDefault(action, value);
		}

        public async Task Run(Func<Task> action)
        {
            await this.Run_OkIfDefault(action);
        }

        public async Task Run_OkIfDefault(Func<Task> action)
        {
            if (action == default)
            {
                return;
            }

            await action();
        }
    }
}