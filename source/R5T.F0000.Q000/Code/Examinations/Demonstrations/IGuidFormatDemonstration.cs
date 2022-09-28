using System;
using System.Collections.Generic;
using System.IO;

using R5T.T0141;


namespace R5T.F0000.Q000
{
	[DemonstrationsMarker]
	public partial interface IGuidFormatDemonstration : IDemonstrationsMarker
	{
		/// <summary>
		/// Shows an example Guid value in multiple formats.
		/// </summary>
		public void ShowFormats_FileOutput()
        {
			var outputFilePath = @"C:\Temp\Guid Formats.txt";

			using var writer = new StreamWriter(outputFilePath)
			{
				AutoFlush = true,
			};

			IGuidFormatDemonstration.ShowFormats(writer);
        }

		private static void ShowFormats(TextWriter writer)
        {
			var formatFunctionsByFormatName = new Dictionary<string, Func<Guid, string>>
			{
				// Show default and standard first.
				{ "<default>", Instances.GuidOperator.ToString },
				{ "Standard", Instances.GuidOperator.ToString_Standard },
				{ "B", Instances.GuidOperator.ToString_B_Format },
				{ "B_Uppercase", Instances.GuidOperator.ToString_B_Uppercase_Format },
				{ "D", Instances.GuidOperator.ToString_D_Format },
				{ "D_Uppercase", Instances.GuidOperator.ToString_D_Uppercase_Format },
				{ "N", Instances.GuidOperator.ToString_N_Format },
				{ "P", Instances.GuidOperator.ToString_P_Format },
				{ "X", Instances.GuidOperator.ToString_X_Format },
			};

			var guidString = Instances.Examples.GuidString;
			var guid = Instances.GuidOperator.Parse(guidString);

			foreach (var pair in formatFunctionsByFormatName)
			{
				writer.WriteLine($"{pair.Key}:{Environment.NewLine}{pair.Value(guid)}{Environment.NewLine}");
			}
		}
	}
}