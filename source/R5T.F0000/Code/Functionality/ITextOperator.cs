using System;
using System.Collections.Generic;
using System.Linq;

using R5T.L0089.T000;
using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ITextOperator : IFunctionalityMarker,
		L0053.ITextOperator
	{
		public string MakeLine(
			string text,
			string newLine)
		{
			var line = text + newLine;
			return line;
		}

		/// <summary>
		/// <para>Ensures the first letter of the word is capitalized.</para>
		/// Robust (not strict) in the sense that empty values do not result in an exception.
		/// </summary>
		public string Ensure_IsCapitalized(string word)
		{
			var hasFirstLetter = this.Has_FirstLetter(word);
			if(hasFirstLetter)
			{
				var firstLetter = hasFirstLetter.Result;

				var isUppercase = Instances.CharacterOperator.Is_Uppercase(firstLetter);
				if(!isUppercase)
				{
					var uppercaseLetter = Instances.CharacterOperator.ToUpper(firstLetter);

					var output = this.Replace_FirstLetter_Unchecked(
						word,
						uppercaseLetter);

					return output;
				}
				else
				{
					return word;
				}
			}
			else
			{
				return word;
			}
		}

		public string Replace_FirstLetter_Unchecked(string word, char replacementLetter)
		{
			var output = replacementLetter + word[1..];
			return output;
		}

		public WasFound<char> Has_FirstLetter(string word)
		{
			var hasFirstLetter = word.Length > 0;

			var output = hasFirstLetter
				? WasFound.Found(
					this.Get_FirstLetter_Unchecked(word))
				: WasFound.NotFound<char>()
				;

			return output;
		}

		public char Get_FirstLetter_Unchecked(string word)
		{
			var output = word[0];
			return output;
		}

		public char Get_FirstLetter_Checked(string word)
		{
			var output = this.Has_FirstLetter(word)
				.Get_Result_OrExceptionIfNotFound("Word had no first letter.");

			return output;
		}

		/// <summary>
		/// Chooses <see cref="Get_FirstLetter_Checked(string)"/> as the default.
		/// </summary>
		public char Get_FirstLetter(string word)
		{
			return this.Get_FirstLetter_Checked(word);
		}

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

		public IEnumerable<string> Tabinate(IEnumerable<string> strings)
		{
			return strings.Select(x => $"\t{x}");
		}
	}
}