using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IConsoleOperator : IFunctionalityMarker
	{
		public void WriteLine(string line)
        {
			Console.WriteLine(line);
        }
	}
}