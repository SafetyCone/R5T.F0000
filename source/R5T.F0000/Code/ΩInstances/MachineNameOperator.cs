using System;


namespace R5T.F0000
{
    public class MachineNameOperator : IMachineNameOperator
    {
        #region Infrastructure

        public static IMachineNameOperator Instance { get; } = new MachineNameOperator();


        private MachineNameOperator()
        {
        }

        #endregion
    }
}
