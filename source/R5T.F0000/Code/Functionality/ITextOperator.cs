using System;
using System.Collections.Generic;using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ITextOperator : IFunctionalityMarker
	{
		public bool EndsWithPeriod(string text)
        {
			var lastCharacter = text.Last();

			var endsWithPeriod = lastCharacter == Instances.Characters.Period;
			return endsWithPeriod;
        }

		public bool EndsWithPeriod_AfterTrimEnd(string text)
        {
			var endTrimmedText = text.TrimEnd();

			var output = this.EndsWithPeriod(endTrimmedText);
			return output;
        }

		public bool EndsWithSentencePunctuation(string text)
        {
			var lastCharacter = text.Last();

			var output = Instances.CharacterSets.SentenceEndings.Contains(lastCharacter);
			return output;
		}

        /// <summary>
        /// Trims the end of the text and ensures it ends with a single period.
        /// </summary>
        public string MakeEndWithPeriod(string text)
        {
            var endTrimmedText = text.TrimEnd(
				Instances.CharacterSets.SentenceEndings_AndSpace);

            var output = endTrimmedText + Instances.Characters.Period;
            return output;
        }

        /// <summary>
        /// Trims both the start and end of the text, then ensures the text ends with a single period.
        /// </summary>
        public string EnsureIsSentence(string text)
        {
			var startTrimmedText = text.TrimStart();

			var endsWithSentencePunctuation = this.EndsWithSentencePunctuation(startTrimmedText);

			var output = endsWithSentencePunctuation
				? startTrimmedText
				: this.MakeEndWithPeriod(startTrimmedText)
				;

			return output;
        }

		/// <summary>
		/// Joins lines using the <see cref="Z0000.IStrings.NewLine"/> separator into a single string of text.
		/// </summary>
		public string JoinLines(IEnumerable<string> lines)
		{
			var output = StringOperator.Instance.Join(
				Instances.Strings.NewLine,
				lines);

			return output;
		}

		/// <summary>
		/// Assumes that the inputs are, in fact, sentences.
		/// </summary>
		public string JoinSentences(IEnumerable<string> sentences)
        {
			var output = Instances.StringOperator.Join(
				Instances.Characters.Space,
				sentences);

			return output;
        }

		public string JoinSentences(params string[] sentences)
        {
			var output = this.JoinSentences(sentences.AsEnumerable());
			return output;
        }
	}
}