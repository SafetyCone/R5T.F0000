using System;
using System.Linq;
using System.Reflection;

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
	public partial interface IExecutablePathOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Get the current executable's path location from the first argument of the command-line incantation used to start the current process.
		/// </summary>
		public string GetExecutableFilePath_ViaCommandLineArgumentValue()
        {
			var commandLineArguments = Instances.CommandLineArgumentsOperator.GetCommandLineArguments();

			// First argument of any command-line incantation is the path of the executable.
			var executableFilePath = commandLineArguments.First();
			return executableFilePath;
        }

		public string GetExecutableFilePath_ViaEntryAssemblyLocation()
        {
			var entryAssembly = Assembly.GetEntryAssembly();

			// The entry assembly will be the executable path.
			var executableFilePath = entryAssembly.Location;
			return executableFilePath;
		}

		/// <summary>
		/// Gets the path location of the executable via the default method, <see cref="IExecutablePathOperator.GetExecutableFilePath_ViaCommandLineArgumentValue()"/>.
		/// </summary>
		/// <remarks>
		/// There are multiple ways to get the location of the executable, and depending on context (unit test, debugging in Visual Studio, or production) different locations are returned.
		/// The command line argument is chosen as the default since this is the way the program is actually run by the operating system.
		/// </remarks>
		public string GetExecutableFilePath()
        {
			var output = this.GetExecutableFilePath_ViaCommandLineArgumentValue();
			return output;
        }
	}
}