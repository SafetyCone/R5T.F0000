﻿using System;


namespace R5T.F0000
{
    public class Failure<T>
    {
        public T Value { get; }
        public string Message { get; }


        public Failure(
            T value,
            string message)
        {
            Value = value;
            Message = message;
        }
    }


    public static class Failure
    {
        public static Failure<T> Of<T>(T value, string message)
        {
            var output = new Failure<T>(value, message);
            return output;
        }
    }
}
