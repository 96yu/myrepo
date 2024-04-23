using System;
using System.Runtime.Serialization;

namespace PFStratCentral.Exceptions
{
    [Serializable]
    internal class InvalidStrategyException : Exception
    {
        public InvalidStrategyException()
        {
        }

        public InvalidStrategyException(string? message) : base(message)
        {
        }

        public InvalidStrategyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidStrategyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
