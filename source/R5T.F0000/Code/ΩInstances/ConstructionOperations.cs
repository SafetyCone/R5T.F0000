using System;


namespace R5T.F0000
{
    public class ConstructionOperations : IConstructionOperations
    {
        #region Infrastructure

        public static IConstructionOperations Instance { get; } = new ConstructionOperations();


        private ConstructionOperations()
        {
        }

        #endregion
    }
}
