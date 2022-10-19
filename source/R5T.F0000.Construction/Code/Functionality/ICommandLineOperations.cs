using System;
using System.Threading;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0000.Construction
{
	[FunctionalityMarker]
	public partial interface ICommandLineOperations : IFunctionalityMarker
	{
		public void EchoCurrentDirectoryAtCommandLine()
        {
			var echoText = "%CD%";

			// Should just output the current directory path. For example: "C:\Code\DEV\Git\GitHub\SafetyCone\R5T.F0000\source\R5T.F0000.Construction\bin\Debug\net5.0"
			CommandLineOperator.Instance.Run_Synchronous(
                Instances.ExecutableNames.Command,
                //"cmd.exe",
                $"/c echo \"{echoText}\"");
        }

		public async Task RunEchoingExecutable()
		{
			var executableFilePath = Instances.ExecutableFilePaths.EchoingExecutableFilePath;

			using var process = Instances.DotnetCommandLineOperator.Start(
				executableFilePath,
				F0000.Instances.CommandLineOperator.Default_DataReceivedHandler,
				F0000.Instances.CommandLineOperator.Default_DataReceivedHandler,
				out var standardInput);

			var waitingForProcessExit = process.WaitForExitAsync();

			Thread.Sleep(Instances.Durations.Short);

			// Write input to the process, should receive output to the parent process console from above.
			Console.WriteLine("Hello?");
			standardInput.WriteLine("Hello?");

			Thread.Sleep(Instances.Durations.Long);

			Console.WriteLine("Is anyone there?");
			standardInput.WriteLine("Is anyone there?");

			Thread.Sleep(Instances.Durations.Long);

			Console.WriteLine("Anyone?");
			standardInput.WriteLine("Anyone?");

			Thread.Sleep(Instances.Durations.Long);

			Console.WriteLine("error:Try error?");
			standardInput.WriteLine("error:Try error?");

			Thread.Sleep(Instances.Durations.Long);

			// Exit
			Console.WriteLine("exit");
			standardInput.WriteLine("exit");

			Thread.Sleep(Instances.Durations.Short);

			await waitingForProcessExit;

			Console.WriteLine($"Process exit code: {process.ExitCode}");
		}

		public void RunEchoingExecutableSynchronously()
		{
			var executableFilePath = Instances.ExecutableFilePaths.EchoingExecutableFilePath;

			using var process = Instances.DotnetCommandLineOperator.Start(
				executableFilePath,
				(sender, e) =>
				{
					Console.WriteLine(e.Data);
				},
				out var standardInput);

			Thread.Sleep(Instances.Durations.Short);

			// Write input to the process, should receive output to the parent process console from above.
			Console.WriteLine("Hello?");
			standardInput.WriteLine("Hello?");

			Thread.Sleep(Instances.Durations.Long);

			Console.WriteLine("Is anyone there?");
			standardInput.WriteLine("Is anyone there?");

			Thread.Sleep(Instances.Durations.Long);

			Console.WriteLine("Anyone?");
			standardInput.WriteLine("Anyone?");

			Thread.Sleep(Instances.Durations.Long);

			// Exit
			Console.WriteLine("exit");
			standardInput.WriteLine("exit");

			Thread.Sleep(Instances.Durations.Short);

			process.WaitForExit();

			Console.WriteLine($"Process exit code: {process.ExitCode}");
		}

		public void RunMinimalExecutable()
		{
			var executableFilePath = Instances.ExecutableFilePaths.MinimalExecutableFilePath;

			using var process = F0000.Instances.CommandLineOperator.Start(
				executableFilePath,
				(sender, e) =>
				{
					Console.WriteLine(e.Data);
				});

			process.WaitForExit();

			Console.WriteLine($"Process exit code: {process.ExitCode}");
		}
	}
}