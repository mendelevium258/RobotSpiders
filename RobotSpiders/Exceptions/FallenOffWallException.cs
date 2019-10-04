using System;
using System.Runtime.Serialization;

namespace RobotSpiders.Exceptions
{
    [Serializable]
    public class FallenOffWallException : Exception
    {
        public FallenOffWallException()
        {
        }

        public FallenOffWallException(string message) : base(message)
        {
        }

        public FallenOffWallException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FallenOffWallException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}