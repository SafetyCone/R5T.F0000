using System;


namespace R5T.F0000.F001
{
	public class ConversionOperator : IConversionOperator
	{
		#region Infrastructure

	    public static IConversionOperator Instance { get; } = new ConversionOperator();

	    private ConversionOperator()
	    {
        }

	    #endregion
	}
}