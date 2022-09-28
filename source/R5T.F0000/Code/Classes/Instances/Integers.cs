using System;


namespace R5T.F0000
{
	public class Integers : IIntegers
	{
		#region Infrastructure

	    public static IIntegers Instance { get; } = new Integers();

	    private Integers()
	    {
        }

	    #endregion
	}
}