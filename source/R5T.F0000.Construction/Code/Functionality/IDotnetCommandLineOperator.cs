using System;
using System.Diagnostics;
using System.IO;

using R5T.T0132;


namespace R5T.F0000.Construction
{
	[FunctionalityMarker]
	public partial interface IDotnetCommandLineOperator : IFunctionalityMarker
	{
        /// <summary>
        /// Configures and starts a dotnet process.
        /// </summary>s
        public Process Start(
            string dotnetArguments,
            DataReceivedEventHandler receiveOutputData,
            out StreamWriter standardInput)
        {
            var process = F0000.Instances.CommandLineOperator.Start(
                Instances.ExecutableNames.Dotnet,
                dotnetArguments,
                receiveOutputData,
                true);

            standardInput = process.StandardInput;

            return process;
        }

        /// <summary>
        /// Configures and starts a dotnet process.
        /// </summary>s
        public Process Start(
            string dotnetArguments,
            DataReceivedEventHandler receiveOutputData,
            DataReceivedEventHandler receiveErrorData,
            out StreamWriter standardInput)
        {
            var process = F0000.Instances.CommandLineOperator.Start(
                Instances.ExecutableNames.Dotnet,
                dotnetArguments,
                receiveOutputData,
                receiveErrorData,
                true);

            standardInput = process.StandardInput;

            return process;
        }
    }
}