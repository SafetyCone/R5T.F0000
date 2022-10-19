using System;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.F0000.Construction
{
	[FunctionalityMarker]
	public partial interface IXmlOperations : IFunctionalityMarker
	{
		public void IsXmlFile()
        {
			var filePath =
                //// Yes.
                //@"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.C0003\source\R5T.C0003\R5T.C0003.csproj"
                // No.
                @"C:\Users\David\Dropbox\Organizations\Rivet\Shared\Data\Instances\Functionality.txt"
                ;

			//// Throws a System.Xml.XmlException: 'Data at the root level is invalid. Line 1, position 1.'
			//var xml = Instances.XmlOperator.Load(filePath);

			//Console.WriteLine(xml);

			var isXmlFile = Instances.XmlFileOperator.IsXmlFile(filePath);

			Console.WriteLine(isXmlFile);
        }
	}
}