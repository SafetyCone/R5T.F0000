using System;


namespace R5T.F0000
{
    /// <summary>
    /// Just use the object class as a dummy.
    /// </summary>
    public class Actions : IActions<object>
    {
        #region Infrastructure

        public static IActions<object> Instance { get; } = new Actions();


        private Actions()
        {
        }

        #endregion
    }
}
