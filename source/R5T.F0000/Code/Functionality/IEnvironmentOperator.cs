using System;
using System.IO;

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

		public void DescribeTo(
			TextWriter writer)
		{
			writer.WriteLine($"{Environment.MachineName}: machine name");
            writer.WriteLine($"{Environment.ProcessorCount}: processor count");

            writer.WriteLine("---");

            writer.WriteLine($"{Environment.OSVersion}: OS version");
            writer.WriteLine($"{Environment.Is64BitOperatingSystem}: is 64-bit OS?");
            writer.WriteLine($"{Environment.SystemDirectory}: system directory");
            writer.WriteLine($"{Environment.TickCount/1000}: time since system start (seconds)");
            writer.WriteLine($"{Environment.SystemPageSize}: system page size");

            writer.WriteLine("---");

            writer.WriteLine($"{Environment.UserName}: user name");
            writer.WriteLine($"{Environment.UserDomainName}: user domain name");

            writer.WriteLine("---");

            writer.WriteLine($"{Environment.UserInteractive}: is process user interactive?");
            writer.WriteLine($"{Environment.CurrentDirectory}: current directory");
            writer.WriteLine($"{Environment.Is64BitProcess}: is 64-bit process?");
            writer.WriteLine($"{Environment.WorkingSet}: process working set size (bytes)");

            writer.WriteLine("---");

            writer.WriteLine($"{Environment.Version}: CLR version");
            writer.WriteLine($"{Environment.HasShutdownStarted}: has CLR shutdown started?");

            writer.WriteLine("---");

            writer.WriteLine($"{Environment.CurrentManagedThreadId}: current managed thread ID");
        }

        public Version GetDotnetRuntimeVersion()
        {
            var output = Environment.Version;
            return output;
        }
	}
}