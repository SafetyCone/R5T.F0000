using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IObjectOperator : IFunctionalityMarker
	{
        public TOutput As<TInput, TOutput>(TInput @object)
            where TOutput : class
        {
            var output = @object as TOutput;
            return output;
        }

        public void ModifyIf<T>(T @object, bool condition, Action<T> modifyAction)
        {
            if(condition)
            {
                modifyAction(@object);
            }
        }
    }
}