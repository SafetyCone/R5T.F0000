using System;

using R5T.T0141;


namespace R5T.F0000.Q000
{
	[DemonstrationsMarker]
	public partial interface IXmlDemonstrations : IDemonstrationsMarker
	{
		public void XmlEncodeString()
        {
			var description = "IServiceAction<T> abstractions library.";

			// Result: "IServiceAction&lt;T&gt; abstractions library."
			var xmlEncodedDescription = F0000.Instances.XmlOperator.EncodeText(description);

			Console.WriteLine(xmlEncodedDescription);

            /// Test vs. <see cref="System.Web.HttpUtility.HtmlEncode(string?)"/>.
            var xmlEncodedDescription01 = Implementations.XmlOperator.Instance.EncodeText_Custom(description);
            var xmlEncodedDescription02 = Implementations.XmlOperator.Instance.EncodeText_HtmlEncode(description);

			var encodingsAreTheSame = xmlEncodedDescription01 == xmlEncodedDescription02;

			Console.WriteLine($"{encodingsAreTheSame}: Encodings are the same.");
        }
	}
}