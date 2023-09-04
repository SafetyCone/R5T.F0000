using System;

using R5T.T0132;


namespace R5T.F0000
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Since PathOperator is not available (it is in F0002, not F0000, yet?), some functionality must be postponed to F0002.
	/// 
	/// Prior work:
	/// * R5T.Magyar.ExecutableFilePathHelper
	/// </remarks>
	[FunctionalityMarker]
	public partial interface IExecutablePathOperator : IFunctionalityMarker,
		L0053.IExecutablePathOperator
	{
        private static L0053.Implementations.IExecutablePathOperator Platform_Implementations => L0053.Implementations.ExecutablePathOperator.Instance;


        /// <inheritdoc cref="L0053.Implementations.IExecutablePathOperator.Get_ExecutableFilePath_ViaCommandLineArgument"/>
        public string GetExecutableFilePath_ViaCommandLineArgumentValue()
        {
			var output = Platform_Implementations.Get_ExecutableFilePath_ViaCommandLineArgument();
			return output;
        }

        /// <inheritdoc cref="L0053.Implementations.IExecutablePathOperator.Get_ExecutableFilePath_ViaEntryAssemblyLocation"/>
        public string GetExecutableFilePath_ViaEntryAssemblyLocation()
        {
			var output = Platform_Implementations.Get_ExecutableFilePath_ViaEntryAssemblyLocation();
			return output;
		}
    }
}