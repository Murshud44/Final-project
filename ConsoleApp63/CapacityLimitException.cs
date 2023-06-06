using System.Runtime.Serialization;

namespace ConsoleApp63
{
    [Serializable]
    internal class CapacityLimitException : Exception
    {
        public CapacityLimitException()
        {
        }

        public CapacityLimitException(string? message) : base(message)
        {
        }

        public CapacityLimitException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CapacityLimitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}