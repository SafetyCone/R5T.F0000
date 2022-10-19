using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IXmlOperator : IFunctionalityMarker
	{
		private static Implementations.IXmlOperator Implementations { get; } = F0000.Implementations.XmlOperator.Instance;


		public XAttribute CreateAttribute(string name, string value)
        {
			var output = new XAttribute(name, value);
			return output;
        }

		public XDeclaration CreateDefaultDeclaration()
        {
			var output = new XDeclaration(
				Instances.XmlStrings.Version_1_0,
				Instances.XmlStrings.Encoding_UTF8,
				Instances.XmlStrings.Standalone_Default);

			return output;
        }

		public XDocument CreateNewDocument(
			XElement root,
			XDeclaration declaration)
        {
			var output = new XDocument(declaration, root);
			return output;
		}

		public XDocument CreateNewDocument_WithDefaultDeclaration(
			XElement root)
		{
			var declaration = this.CreateDefaultDeclaration();

            var output = this.CreateNewDocument(
                root,
                declaration);

            return output;
		}

		/// <summary>
		/// Quality-of-life overload for <see cref="CreateNewDocument_WithoutDefaultDeclaration()"/>
		/// </summary>
		public XDocument CreateNewDocument_Empty()
        {
			var document = this.CreateNewDocument_WithoutDefaultDeclaration();
			return document;
        }

		public XDocument CreateNewDocument_WithoutDefaultDeclaration(
			XElement root)
		{
			var output = new XDocument(root);
			return output;
		}

		/// <summary>
		/// Chooses <see cref="CreateNewDocument_WithDefaultDeclaration(XElement)"/> as the default.
		/// </summary>
		public XDocument CreateNewDocument(
			XElement root)
        {
			var output = this.CreateNewDocument_WithDefaultDeclaration(root);
			return output;
        }

		public XDocument CreateNewDocument_WithoutDefaultDeclaration()
        {
			var output = new XDocument();
			return output;
        }

		public XDocument CreateNewDocument_WithDefaultDeclaration()
		{
			var declaration = this.CreateDefaultDeclaration();

			var output = new XDocument(declaration);
			return output;
		}

		/// <summary>
		/// Chooses <see cref="CreateNewDocumentWithRoot_WithXsdAndXsi(string)"/> as the default.
		/// </summary>
		public XDocument CreateNewDocumentWithRoot(
			string rootElementName)
        {
			var output = this.CreateNewDocumentWithRoot_WithXsdAndXsi(rootElementName);
			return output;
        }

		public XDocument CreateNewDocumentWithRoot_WithXsdAndXsi(
			string rootElementName)
        {
			var document = this.CreateNewDocumentWithRoot_WithoutXsdAndXsi(rootElementName);

			var root = document.Root;

			var xmlSchemaDefinitionAttribute = Instances.XmlOperator.GetXmlnsXsdAttribute();

			root.Add(xmlSchemaDefinitionAttribute);

			var xmlSchemaInstanceAttribute = Instances.XmlOperator.GetXmlnsXsiAttribute();

			root.Add(xmlSchemaInstanceAttribute);

			return document;
		}

		public XDocument CreateNewDocumentWithRoot_WithoutXsdAndXsi(
			string rootElementName)
        {
			var document = Instances.XmlOperator.CreateNewDocument();

			var root = Instances.XElementOperator.CreateElement(rootElementName);

			document.Add(root);

			return document;
		}

		/// <summary>
		/// Chooses <see cref="CreateNewDocument_WithDefaultDeclaration()"/> as the deafult.
		/// </summary>
		public XDocument CreateNewDocument()
		{
			var output = this.CreateNewDocument_WithDefaultDeclaration();
			return output;
		}

		public string EncodeText(string text)
        {
			var encodedText = Implementations.EncodeText_Custom(text);
			return encodedText;
        }

		public XName GetLocalName(
			XNamespace @namespace,
			string localName)
        {
			var output = @namespace.GetName(localName);
			return output;
        }

		public XNamespace GetXsiNamespace()
        {
			var output = this.GetXmlNamespace(Instances.XmlStrings.XmlSchemaInstance_Url);
			return output;
        }

		public XName GetXsiNamespacedName(string localName)
		{
			var xsiNamespace = this.GetXsiNamespace();

			var output = xsiNamespace.GetName(localName);
			return output;
		}

		public XAttribute GetXsiTypeAttribute(string typeName)
        {
			var output = new XAttribute(
				this.GetXsiTypeName(),
				typeName);

			return output;
        }

		public XName GetXsiTypeName()
		{
			var output = this.GetXsiNamespacedName(Instances.XmlStrings.Type);
			return output;
		}

		public XAttribute GetXmlnsXsdAttribute()
        {
			var output = new XAttribute(
				Instances.XmlOperator.GetLocalName(
					Instances.XmlOperator.GetXmlnsNamespace(),
					Instances.XmlStrings.XmlSchemaDefinition_Name),
				Instances.XmlStrings.XmlSchemaDefinition_Url);

			return output;
		}

		public XAttribute GetXmlnsXsiAttribute()
		{
			var output = new XAttribute(
				Instances.XmlOperator.GetLocalName(
					Instances.XmlOperator.GetXmlnsNamespace(),
					Instances.XmlStrings.XmlSchemaInstance_Name),
				Instances.XmlStrings.XmlSchemaInstance_Url);

			return output;
		}

		public XNamespace GetXmlnsNamespace()
		{
			var output = XNamespace.Xmlns;
			return output;
		}

		public XNamespace GetXmlNamespace(string name)
		{
			/// Yes, it's an implicit conversion.
			XNamespace output = name;
			return output;
		}

		public XNamespace GetXmlNamespaceNamespace()
        {
			var output = this.GetXmlnsNamespace();
			return output;
        }

		public XDocument Load_XDocument(string xmlFilePath)
        {
			var xDocument = XDocument.Load(xmlFilePath, LoadOptions.None);
			return xDocument;
        }

		/// <summary>
		/// Chooses <see cref="Load_XDocument(string)"/> as the default.
		/// </summary>
		public XDocument Load(string xmlFilePath)
        {
			var xDocument = this.Load_XDocument(xmlFilePath);
			return xDocument;
        }

		/// <summary>
		/// Quality-of-life overload for <see cref="Write(XDocument, string)"/>.
		/// </summary>
		public void Save(
			XDocument xDocument,
			string xmlFilePath)
        {
			this.Write(
				xDocument,
				xmlFilePath);
        }

		/// <summary>
		/// Chooses <see cref="WriteToFile_EmptyIsOk(XDocument, string)"/> as the default.
		/// </summary>
		public void Write(
			XDocument xDocument,
			string xmlFilePath)
        {
			this.WriteToFile_EmptyIsOk(
				xDocument,
				xmlFilePath);
        }

		/// <summary>
		/// XML files *must* have a root: https://www.w3schools.com/xml/xml_syntax.asp
		/// So if the document has no root, saving the document results in an <see cref="InvalidOperationException"/>: Token EndDocument in state Document would result in an invalid XML document.
		/// This method will allow writing an empty document.
		/// If the document has no root, just the declaration is written.
		/// If the document also has no declaration, nothing is written.
		/// </summary>
		public void WriteToFile_EmptyIsOk(
			XDocument xDocument,
			string xmlFilePath)
        {
			if (xDocument.Root is null)
            {
				if(xDocument.Declaration is null)
                {
					Instances.FileOperator.WriteAnEmptyFile(xmlFilePath);
                }
                else
                {
					var text = xDocument.Declaration.ToString();

					Instances.FileOperator.WriteText(
						xmlFilePath,
						text); 
                }
            }
			else
            {
				xDocument.Save(xmlFilePath);
            }
        }
	}
}