using System;


namespace R5T.F0000
{
    public class ActionOperations : IActionOperations
    {
        #region Infrastructure

        public static IActionOperations Instance { get; } = new ActionOperations();


        private ActionOperations()
        {
        }

        #endregion
    }
}
