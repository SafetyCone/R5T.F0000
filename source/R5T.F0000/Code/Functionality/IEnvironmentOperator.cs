using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IEnvironmentOperator : IFunctionalityMarker
	{
		public string GetCurrentDirectory()
        {
			var output = Environment.CurrentDirectory;
			return output;
        }

		/// <summary>
		/// Returns true if the DEBUG preprocessor context symbol has been defined. False otherwise.
		/// </summary>
		public bool IsDebugCompilationConfiguration()
        {
#if DEBUG
			return true;
#else
			return false;
#endif
		}
	}
}