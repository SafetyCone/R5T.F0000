using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.L0089.T000;
using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
	public partial interface IXElementOperator : IFunctionalityMarker,
		L0053.IXElementOperator
	{
		/// <summary>
		/// Uses the <see cref="XName.LocalName"/>.
		/// </summary>
		public IEnumerable<XElement> WhereNameIs(
			IEnumerable<XElement> xElements,
			string name)
		{
			var output = xElements.Where(xElement => xElement.Name.LocalName == name);
			return output;
		}

		public WasFound<XElement> HasChildWithChild_Single<TElement>(TElement element,
			string childName,
			string grandChildName)
			where TElement : XElement
        {
			var outputOrDefault = element.Elements()
				.WhereNameIs(childName)
				.Where(xElement => xElement.HasChild_Any(grandChildName))
				.SingleOrDefault();

			var wasFound = WasFound.From(outputOrDefault);
			return wasFound;
		}

		public WasFound<XElement> HasChildOfChild_Single<TElement>(TElement element,
			string childName,
			string grandChildName)
			where TElement : XElement
		{
			var outputOrDefault = element.Elements()
				.WhereNameIs(childName)
				.SelectMany(childElement => childElement.Elements()
					.WhereNameIs(grandChildName))
				.SingleOrDefault();

			var wasFound = WasFound.From(outputOrDefault);
			return wasFound;
		}

		public WasFound<string> HasChildOfChildValue_Single<TElement>(TElement element,
			string childName,
			string grandChildName)
			where TElement : XElement
        {
			var childOfChildWasFound = this.HasChildOfChild_Single(
				element,
				childName,
				grandChildName);

			var valueWasFound = childOfChildWasFound.Convert(x => x.Value);
			return valueWasFound;
        }

		public XElement GetChild_Single<TElement>(TElement element, string childName)
			where TElement : XElement
		{
			var wasFound = this.HasChild_Single(element, childName);
			if (!wasFound)
			{
				throw new Exception($"No child found with name: '{childName}'");
			}

			return wasFound.Result;
		}

		/// <summary>
		/// Chooses <see cref="GetChild_Single{TElement}(TElement, string)"/> as the default.
		/// </summary>
		public XElement GetChild<TElement>(TElement element, string childName)
			where TElement : XElement
		{
			var wasFound = this.GetChild_Single(element, childName);
			return wasFound;
		}

		public IEnumerable<XElement> GetChildren(XElement element)
		{
			var output = element.Elements();
			return output;
		}

		public string GetName(XElement element)
			=> this.Get_Name(element);

		public WasFound<XElement> HasChild_Single<TElement>(TElement element, string childName)
			where TElement : XElement
		{
			// If empty, shortcut.
			if (!element.HasElements)
			{
				return WasFound.NotFound<XElement>();
			}

			var outputOrDefault = element.Elements()
				.Where(xElement => xElement.Name.LocalName == childName)
				.SingleOrDefault();

			var wasFound = WasFound.From(outputOrDefault);
			return wasFound;
		}

		/// <summary>
		/// Chooses <see cref="HasChild_Single{TElement}(TElement, string)"/> as the default.
		/// </summary>
		public WasFound<XElement> HasChild<TElement>(TElement element, string childName)
			where TElement : XElement
		{
			var wasFound = this.HasChild_Single(element, childName);
			return wasFound;
		}
	}
}