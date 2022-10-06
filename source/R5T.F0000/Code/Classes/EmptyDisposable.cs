using System;


namespace R5T.F0000
{
    /// <summary>
    /// An empty disposable whose <see cref="Dispose"/> method does nothing.
    /// </summary>
    public class EmptyDisposable : IDisposable
    {
        #region Static

        public static EmptyDisposable Instance { get; } = new EmptyDisposable();

        #endregion


        private EmptyDisposable()
        {
        }

        /// <inheritdoc/>
        public void Dispose()
        {
        }
    }
}
