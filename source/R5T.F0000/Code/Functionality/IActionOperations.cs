using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IActionOperations : IFunctionalityMarker
    {
        public Func<T, Task> Combine_Asynchronously<T>(IEnumerable<Action<T>> actions)
        {
            Task Internal(T value)
            {
                Instances.ActionOperator.Run_Actions(
                    value,
                    actions);

                return Task.CompletedTask;
            }

            return Internal;
        }

        /// <summary>
        /// The correct usage is:
        /// <code>public Action&lt;RepositoryContext&gt; Default => Instances.ActionOperations.DoNothing_Synchronous;</code>
        /// (No need for a double arrow, => ... => ...;)
        /// </summary>
        public void DoNothing_Synchronous<T>(T value)
        {
            // Do nothing.
        }

        public Task DoNothing<T>(T value)
        {
            // Do nothing.
            return Task.CompletedTask;
        }
    }
}
