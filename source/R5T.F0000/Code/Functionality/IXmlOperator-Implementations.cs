using System;
using System.Web;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.F0000.Implementations
{
	[FunctionalityMarker]
	public partial interface IXmlOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Encodes special characters in text to allow the text to be a value in an XML file.
		/// See: <see href="https://weblogs.sqlteam.com/mladenp/2008/10/21/different-ways-how-to-escape-an-xml-string-in-c/"/>
		/// </summary>
		/// <remarks>
		/// This implementation simply replaces the five special XML characters.
		/// </remarks>
		public string EncodeText_Custom(string text)
        {
			var encodedText = text
				// Do ampersand first, since otherwise we would replace the ampersands in already replaced values.
				.Replace(
					Instances.Strings.Ampersand,
					"&amp;")
				.Replace(
					Instances.Strings.LessThan,
					"&lt;")
				.Replace(
					Instances.Strings.GreaterThan,
					"&gt;")
				.Replace(
					Instances.Strings.Quote,
					"&quot;")
				.Replace(
					Instances.Strings.Apostrophe,
					"&apos;")
				;

			return encodedText;
		}

		/// <summary>
		/// <inheritdoc cref="EncodeText_Custom(string)" path="/summary"/>
		/// </summary>
		/// <remarks>
		/// This implementation uses the <see cref="HttpUtility.HtmlEncode(string?)"/> method.
		/// </remarks>
		public string EncodeText_HtmlEncode(string text)
        {
			var encodedText = HttpUtility.HtmlEncode(text);
			return encodedText;
        }
	}
}