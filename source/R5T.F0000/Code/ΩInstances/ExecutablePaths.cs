using System;


namespace R5T.F0000
{
    public class ExecutablePaths : IExecutablePaths
    {
        #region Infrastructure

        public static IExecutablePaths Instance { get; } = new ExecutablePaths();


        private ExecutablePaths()
        {
        }

        #endregion
    }
}
