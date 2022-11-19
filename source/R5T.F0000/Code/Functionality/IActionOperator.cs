using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IActionOperator : IFunctionalityMarker
	{
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