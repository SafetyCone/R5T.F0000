using System;
using System.IO;
using System.Xml;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IXmlWriterOperator : IFunctionalityMarker
	{
        /// <summary>
        /// The System XML writer includes an XML declaration by default, however this is often not desired.
        /// An XML writer can be created with settings specifying to omit the XML declaration, but other settings must be set to get the desired default behavior.
        /// This method produces an XML writer that omits the declaration.
        /// </summary>
        public XmlWriter NewOmitDeclaration_Synchronous(Stream stream)
        {
            var settings = Instances.XmlWriterSettingsOperator.GetNoDeclaration_Synchronous();

            var writer = XmlWriter.Create(stream, settings);
            return writer;
        }

        /// <inheritdoc cref="NewOmitDeclaration_Synchronous(Stream)"/>
        public XmlWriter NewOmitDeclaration(Stream stream)
        {
            var settings = Instances.XmlWriterSettingsOperator.GetNoDeclaration();

            var writer = XmlWriter.Create(stream, settings);
            return writer;
        }

        /// <summary>
        /// Gets the standard XML writer.
        /// </summary>
        public XmlWriter New_Synchronous(Stream stream)
        {
            var settings = Instances.XmlWriterSettingsOperator.GetStandardSettings();

            var writer = XmlWriter.Create(stream, settings);
            return writer;
        }

        /// <inheritdoc cref="New_Synchronous(Stream)"/>
        public XmlWriter New(Stream stream)
        {
            var settings = Instances.XmlWriterSettingsOperator.GetStandardSettings();

            var writer = XmlWriter.Create(stream, settings);
            return writer;
        }

        public XmlWriter New(TextWriter textWriter)
        {
            var settings = Instances.XmlWriterSettingsOperator.GetStandardSettings();

            var writer = XmlWriter.Create(textWriter, settings);
            return writer;
        }

        public XmlWriter New(string xmlFilePath)
        {
            var settings = Instances.XmlWriterSettingsOperator.GetStandardSettings();

            var writer = XmlWriter.Create(xmlFilePath, settings);
            return writer;
        }
    }
}