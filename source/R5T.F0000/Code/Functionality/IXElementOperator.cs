using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.T0132;
using R5T.T0221;


namespace R5T.F0000
{
    [FunctionalityMarker]
	public partial interface IXElementOperator : IFunctionalityMarker,
		L0053.IXElementOperator
	{
		/// <summary>
		/// Creates an <see cref="XElement"/> with the child name, adds it to the parent, and returns the child.
		/// </summary>
		/// <returns>The child <see cref="XElement"/>.</returns>
		public XElement AddChild(XElement parentElement, string childName)
		{
			var child = this.Create_Element_FromName(childName);

			parentElement.Add(child);

			return child;
		}

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

		public string GetName(XElement xElement)
		{
			var name = xElement.Name.LocalName;
			return name;
		}

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

		public bool HasChild_Any<TElement>(TElement element, string childName)
			where TElement : XElement
		{
			// If empty, shortcut.
			if (!element.HasElements)
			{
				return false;
			}

			var output = element.Elements()
				.Where(xElement => xElement.Name.LocalName == childName)
				.Any();

			return output;
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