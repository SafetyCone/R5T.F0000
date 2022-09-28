using System;
using System.Threading.Tasks;


namespace R5T.F0000.Construction
{
    static class Program
    {
        static async Task Main()
        {
            Instances.CommandLineOperations.EchoCurrentDirectoryAtCommandLine();
            //Instances.CommandLineOperations.RunMinimalExecutable();
            //Instances.CommandLineOperations.RunEchoingExecutableSynchronously();
            //await Instances.CommandLineOperations.RunEchoingExecutable();
        }
    }
}