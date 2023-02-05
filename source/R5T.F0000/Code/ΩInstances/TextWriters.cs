using System;


namespace R5T.F0000
{
    public class TextWriters : ITextWriters
    {
        #region Infrastructure

        public static ITextWriters Instance { get; } = new TextWriters();


        private TextWriters()
        {
        }

        #endregion
    }
}
