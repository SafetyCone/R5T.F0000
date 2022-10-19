using System;
using System.Threading;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ISyncOverAsyncOperator : IFunctionalityMarker
	{
        public void ExecuteTaskSynchronously(Task task)
        {
            // Force synchronously executing thread to wait for the asynchrous work to to be done.
            var semaphore = new SemaphoreSlim(0);

            async Task ExecuteTaskAsynchronously()
            {
                await task;

                semaphore.Release();
            }

            // Fire and forget in the threadpool.
            var executionTask = ExecuteTaskAsynchronously();

            semaphore.Wait();

            if (executionTask.IsFaulted)
            {
                throw executionTask.Exception;
            }
        }

        public void ExecuteSynchronously(Func<Task> action)
        {
            // Force synchronously executing thread to wait for the asynchrous work to to be done.
            var semaphore = new SemaphoreSlim(0);

            async Task ExecuteTaskAsynchronously()
            {
                await action();

                semaphore.Release();
            }

            // Fire and forget in the threadpool.
            var executionTask = ExecuteTaskAsynchronously();

            semaphore.Wait();

            if (executionTask.IsFaulted)
            {
                throw executionTask.Exception;
            }
        }
    }
}