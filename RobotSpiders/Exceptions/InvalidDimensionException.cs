using System;
using System.Runtime.Serialization;

namespace RobotSpiders.Exceptions
{
    [Serializable]
    public class InvalidDimensionException : Exception
    {
        public InvalidDimensionException()
        {
        }

        public InvalidDimensionException(string message) : base(message)
        {
        }

        public InvalidDimensionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDimensionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
