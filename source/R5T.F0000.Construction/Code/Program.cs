using System;
using System.Threading.Tasks;


namespace R5T.F0000.Construction
{
    static class Program
    {
        static async Task Main()
        {
            //Instances.CommandLineExplorations.RunMinimalExecutable();
            //Instances.CommandLineExplorations.RunEchoingExecutableSynchronously();
            await Instances.CommandLineExplorations.RunEchoingExecutable();

            //Instances.GuidFormatDemonstration.ShowFormats_FileOutput();
        }
    }
}