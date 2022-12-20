using System;

using R5T.T0132;

using Glossary = R5T.Y0000.Glossary;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public interface IIndexOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Gets the last <inheritdoc cref="Glossary.ForIndex.Exclusive" path="/name"/> index from a last <inheritdoc cref="Glossary.ForIndex.Inclusive" path="/name"/> index by adding one.
        /// <para><inheritdoc cref="Glossary.ForIndex.ExclusiveInclusiveRelationship" path="/definition"/></para>
        /// </summary>
        public int GetLastExclusiveIndex(int lastIndex_Inclusive)
        {
            var output = lastIndex_Inclusive + 1;
            return output;
        }

        public bool IsFound(int index)
        {
            var output = Index.Instance.NotFound != index;
            return output;
        }
    }
}
