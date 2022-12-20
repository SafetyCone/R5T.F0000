using System;


namespace R5T.F0000
{
	public class StringOperator : IStringOperator
	{
    	#region Infrastructure

	    public static IStringOperator Instance { get; } = new StringOperator();

	    private StringOperator()
	    {
	    }

    	#endregion
	}
}


namespace R5T.F0000.Internal
{
    public class StringOperator : IStringOperator
    {
        #region Infrastructure

        public static IStringOperator Instance { get; } = new StringOperator();

        private StringOperator()
        {
        }

        #endregion
    }
}