using System;


namespace R5T.F0000
{
    public class CancellationTokens : ICancellationTokens
    {
        #region Infrastructure

        public static ICancellationTokens Instance { get; } = new CancellationTokens();


        private CancellationTokens()
        {
        }

        #endregion
    }
}
