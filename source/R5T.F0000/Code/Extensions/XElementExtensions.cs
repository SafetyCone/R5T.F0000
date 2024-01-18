using System;
using System.Collections.Generic;
using System.Xml.Linq;

using R5T.T0221;

using Instances = R5T.F0000.Instances;


namespace System
{
    public static class XElementExtensions
    {
        public static IEnumerable<XElement> Children(this XElement element)
        {
            var output = Instances.XElementOperator.GetChildren(element);
            return output;
        }

        public static XElement GetChild<TElement>(this TElement element, string childName)
            where TElement : XElement
        {
            var output = Instances.XElementOperator.GetChild(element, childName);
            return output;
        }

        public static WasFound<XElement> HasChild_Single<TElement>(this TElement element, string childName)
            where TElement : XElement
        {
            var wasFound = Instances.XElementOperator.HasChild_Single(element, childName);
            return wasFound;
        }

        public static bool HasChild_Any<TElement>(this TElement element, string childName)
            where TElement : XElement
        {
            var output = Instances.XElementOperator.HasChild_Any(element, childName);
            return output;
        }

        /// <summary>
		/// Chooses <see cref="HasChild_Single{TElement}(TElement, string)"/> as the default.
		/// </summary>
		public static WasFound<XElement> HasChild<TElement>(this TElement element, string childName)
            where TElement : XElement
        {
            var wasFound = element.HasChild_Single(childName);
            return wasFound;
        }

        public static WasFound<XElement> HasChildWithChild_Single<TElement>(this TElement element,
            string childName,
            string grandChildName)
            where TElement : XElement
        {
            var wasFound = Instances.XElementOperator.HasChildWithChild_Single(
                element,
                childName,
                grandChildName);

            return wasFound;
        }

        public static WasFound<XElement> HasChildOfChild_Single<TElement>(this TElement element,
            string childName,
            string grandChildName)
            where TElement : XElement
        {
            var wasFound = Instances.XElementOperator.HasChildOfChild_Single(
                element,
                childName,
                grandChildName);

            return wasFound;
        }

        public static WasFound<string> HasChildOfChildValue_Single<TElement>(this TElement element,
            string childName,
            string grandChildName)
            where TElement : XElement
        {
            var valueWasFound = Instances.XElementOperator.HasChildOfChildValue_Single(
                element,
                childName,
                grandChildName);

            return valueWasFound;
        }
    }
}


namespace System.Linq
{
    public static class XElementExtensions
    {
        /// <inheritdoc cref="R5T.F0000.IXElementOperator.WhereNameIs(IEnumerable{XElement}, string)"/>
        public static IEnumerable<XElement> WhereNameIs(this IEnumerable<XElement> xElements,
            string name)
        {
            var output = Instances.XElementOperator.WhereNameIs(xElements, name);
            return output;
        }
    }
}
