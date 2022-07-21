using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public interface IStringOperator : IFunctionalityMarker
	{
        public bool ContainsAny(
            string @string,
            string[] searchStrings)
        {
            var index = this.IndexOfAny(@string, searchStrings);

            var wasFound = this.WasFound(index);
            return wasFound;
        }

        public char GetLastCharacter(string @string)
        {
			var output = @string[^1];
			return output;
        }

        public int IndexOfAny(
            string @string,
            string[] searchStrings)
        {
            foreach (var searchString in searchStrings)
            {
                var index = @string.IndexOf(searchString);

                var wasFound = this.WasFound(index);
                if (wasFound)
                {
                    return index;
                }
            }

            return Instances.String.IndexOfNotFound;
        }

        public bool IsNullOrEmpty(string @string)
        {
            var output = System.String.IsNullOrEmpty(@string);
            return output;
        }

        public string Trim(string @string)
        {
			var output = @string.Trim();
			return output;
        }

		public bool NotFound(int index)
        {
			var output = index == Instances.String.IndexOfNotFound;
			return output;
		}

		public bool WasFound(int index)
        {
			var output = index != Instances.String.IndexOfNotFound;
			return output;
        }
	}
}