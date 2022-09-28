using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace System.Extensions
{
    public static class ProcessExtensions
    {
        public static Task WaitForExitAsync(this Process process)
        {
            return Task.Run(() =>
            {
                process.WaitForExit();
            });
        }
    }
}
