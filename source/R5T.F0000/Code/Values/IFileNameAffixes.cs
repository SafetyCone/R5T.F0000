using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IFileNameAffixes : IValuesMarker
	{
		public string Backup => this.BAK;
		public string BAK => "BAK";
	}
}