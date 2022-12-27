using System;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IDirectoryNameOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Converts a name into a string capable of being a directory name.
        /// </summary>
        /// <remarks>
        /// See <see href="https://learn.microsoft.com/en-us/windows/win32/fileio/naming-a-file#naming-conventions"/>.
        /// </remarks>
        public string ConvertToDirectoryName(string name)
        {
            var currentName = name;

            // Replace all invalid characters with '_'.
            var invalidCharacters = PathOperator.Instance.GetInvalidFileNameCharacters();

            currentName = StringOperator.Instance.Replace(
                currentName,
                Instances.Characters.Underscore,
                invalidCharacters);

            // Trim the ending of any spaces (' ') or periods ('.').
            currentName = currentName.TrimEnd(
                Instances.Characters.Space,
                Instances.Characters.Period);

            return currentName;
        }

        public string Get_DatedDirectoryName(DateTime date)
        {
            var yyyymmdd = DateOperator.Instance.ToString_YYYYMMDD(date);

            // Any YYYYMMDD is already a valid directory name.
            return yyyymmdd;
        }

        public string Get_DateTimedDirectoryName(DateTime dateTime)
        {
            var yyyymmdd_hhmmss = DateOperator.Instance.ToString_YYYYMMDD_HHMMSS(dateTime);

            // Any yyyymmdd_hhmmss is already a valid directory name.
            return yyyymmdd_hhmmss;
        }
    }
}
