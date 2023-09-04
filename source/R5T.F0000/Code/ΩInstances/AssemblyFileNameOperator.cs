using System;


namespace R5T.F0000
{
    public class AssemblyFileNameOperator : IAssemblyFileNameOperator
    {
        #region Infrastructure

        public static IAssemblyFileNameOperator Instance { get; } = new AssemblyFileNameOperator();


        private AssemblyFileNameOperator()
        {
        }

        #endregion
    }
}
