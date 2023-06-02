using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IOrderOperator : IFunctionalityMarker
    {
        private static Internal.IOrderOperator Internal => F0000.Internal.OrderOperator.Instance;


        /// <summary>
        /// Orders elements by name, given names in order.
        /// Any elements whose name is not in the list are appended to the ordered list, in encountered order.
        /// </summary>
        public IEnumerable<TElement> OrderByNames<TElement>(
            IEnumerable<TElement> elements,
            Func<TElement, string> nameSelector,
            IEnumerable<string> orderedNames)
        {
            var orderIndicesByName = Internal.GetOrderIndicesByName(orderedNames);

            var orderableNodes = new List<(int, TElement)>();
            var unorderableNodes = new List<TElement>();

            foreach (var element in elements)
            {
                var index = Internal.GetIndex(
                    element,
                    orderIndicesByName,
                    nameSelector);

                var indexIsFound = IndexOperator.Instance.IsFound(index);
                if (indexIsFound)
                {
                    orderableNodes.Add((index, element));
                }
                else
                {
                    unorderableNodes.Add(element);
                }
            }

            var orderedNodes = orderableNodes
                .OrderBy(x => x.Item1)
                .Select(x => x.Item2)
                .AppendRange(unorderableNodes)
                ;

            return orderedNodes;
        }

        /// <inheritdoc cref="OrderByNames{TElement}(IEnumerable{TElement}, Func{TElement, string}, IEnumerable{string})"/>
        public IEnumerable<TElement> OrderByNames<TElement>(
            IEnumerable<TElement> elements,
            Func<TElement, string> nameSelector,
            params string[] orderedNames)
        {
            return this.OrderByNames(
                elements,
                nameSelector,
                orderedNames.AsEnumerable());
        }
    }
}


namespace R5T.F0000.Internal
{
    [FunctionalityMarker]
    public partial interface IOrderOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Used in ordering objects by explicit name order.
        /// </summary>
        public Dictionary<string, int> GetOrderIndicesByName(IEnumerable<string> orderedNames)
        {
            var counter = 0;

            var orderIndicesByName = orderedNames
                .ToDictionary(
                    x => x,
                    x => counter++);

            return orderIndicesByName;
        }

        public int GetIndex<TElement>(
            TElement element,
            Dictionary<string, int> orderIndicesByName,
            Func<TElement, string> nameSelector)
        {
            var name = nameSelector(element);

            var isSpecified = orderIndicesByName.ContainsKey(name);

            var index = isSpecified
                ? orderIndicesByName[name]
                : Index.Instance.NotFound
                ;

            return index;
        }
    }
}