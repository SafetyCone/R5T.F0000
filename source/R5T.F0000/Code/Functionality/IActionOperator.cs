using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IActionOperator : IFunctionalityMarker
	{
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
	}
}