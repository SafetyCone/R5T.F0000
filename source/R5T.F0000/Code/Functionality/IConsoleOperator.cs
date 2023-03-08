using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IConsoleOperator : IFunctionalityMarker
	{
		public void WriteLines<T>(
			IEnumerable<T> values,
			Func<T, string> describer)
		{
			var lines = values
				.Select(describer)
				;

			this.WriteLines(lines);
		}

		public void WriteLines(IEnumerable<string> lines)
		{
			foreach (var line in lines)
			{
				this.WriteLine(line);
			}
		}

		public void WriteLine(string line)
        {
			Console.WriteLine(line);
        }
	}
}