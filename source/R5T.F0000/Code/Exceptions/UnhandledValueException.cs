using System;
//using System.Runtime.Serialization;


namespace R5T.F0000
{
    public class UnhandledValueException<TValue> : Exception
    {
        //protected const string ValuePropertyName = "Value";


        public TValue Value { get; private set; }


        public UnhandledValueException()
            : base()
        {
        }

        public UnhandledValueException(string message)
            : base(message)
        {
        }

        public UnhandledValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        //protected UnhandledValueException(SerializationInfo info, StreamingContext context)
        //    : base(info, context)
        //{
        //    var valueStringRepresentation = info.GetString(UnhandledValueException<TValue>.ValuePropertyName);

        //    this.Value = Instances.EnumerationOperator.GetValue<TEnum>(valueStringRepresentation);
        //}

        //public override void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    base.GetObjectData(info, context);

        //    info.AddValue(UnexpectedEnumerationValueException<TEnum>.ValuePropertyName, this.Value.ToString());
        //}

        public UnhandledValueException(TValue value)
            : this(Internal.ExceptionOperator.Instance.Get_UnhandledValueExceptionMessage(value))
        {
            this.Value = value;
        }

        public UnhandledValueException(TValue value, string message)
            : this(message)
        {
            this.Value = value;
        }

        public UnhandledValueException(TValue value, string message, Exception innerException)
            : this(message, innerException)
        {
            this.Value = value;
        }
    }
}
