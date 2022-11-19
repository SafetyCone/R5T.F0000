using System;


namespace R5T.F0000
{
	public class MessageOperator : IMessageOperator
	{
		#region Infrastructure

	    public static IMessageOperator Instance { get; } = new MessageOperator();

	    private MessageOperator()
	    {
        }

	    #endregion
	}
}