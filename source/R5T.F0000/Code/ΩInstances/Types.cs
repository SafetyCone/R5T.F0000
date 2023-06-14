using System;


namespace R5T.F0000
{
    public class Types : ITypes
    {
        #region Infrastructure

        public static ITypes Instance { get; } = new Types();


        private Types()
        {
        }

        #endregion
    }
}
