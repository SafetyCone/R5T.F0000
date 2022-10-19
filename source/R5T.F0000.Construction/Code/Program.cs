using System;
using System.Threading.Tasks;


namespace R5T.F0000.Construction
{
    static class Program
    {
        static async Task Main()
        {
            //Instances.CommandLineOperations.EchoCurrentDirectoryAtCommandLine();
            //Instances.CommandLineOperations.RunMinimalExecutable();
            //Instances.CommandLineOperations.RunEchoingExecutableSynchronously();
            //await Instances.CommandLineOperations.RunEchoingExecutable();

            //Instances.FileOperations.HasByteOrderMark();

            //Instances.TypeOperations.IsGeneric_ForOpenGeneric();
            //Instances.TypeOperations.IsGeneric_ForClosedGeneric();
            //Instances.TypeOperations.IsOpenGeneric();
            //Instances.TypeOperations.IsClosedGeneric_ForPartiallyClosedGeneric();
            Instances.TypeOperations.IsClosedGeneric();
            //Instances.TypeOperations.IsCostructedGeneric_ForNonGeneric();
            //Instances.TypeOperations.IsConstructed();

            //Instances.XmlOperations.IsXmlFile();
        }
    }
}