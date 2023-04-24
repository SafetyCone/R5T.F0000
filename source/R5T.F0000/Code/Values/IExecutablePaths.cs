using System;

using R5T.T0131;


namespace R5T.F0000
{
    [ValuesMarker]
    public partial interface IExecutablePaths : IValuesMarker
    {
        public string ExecutableDirectoryPath => Instances.ExecutablePathOperator.GetExecutableDirectoryPath();
        public string ExecutableFilePath => Instances.ExecutablePathOperator.Get_ExecutableFilePath();
    }
}
