using System;


namespace R5T.F0000
{
    public class OrderOperator : IOrderOperator
    {
        #region Infrastructure

        public static IOrderOperator Instance { get; } = new OrderOperator();


        private OrderOperator()
        {
        }

        #endregion
    }
}


namespace R5T.F0000.Internal
{
    public class OrderOperator : IOrderOperator
    {
        #region Infrastructure

        public static IOrderOperator Instance { get; } = new OrderOperator();


        private OrderOperator()
        {
        }

        #endregion
    }
}
