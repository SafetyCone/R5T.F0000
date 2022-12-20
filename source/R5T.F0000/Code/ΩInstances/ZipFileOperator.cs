using System;


namespace R5T.F0000
{
    public class ZipFileOperator : IZipFileOperator
    {
        #region Infrastructure

        public static IZipFileOperator Instance { get; } = new ZipFileOperator();


        private ZipFileOperator()
        {
        }

        #endregion
    }
}
