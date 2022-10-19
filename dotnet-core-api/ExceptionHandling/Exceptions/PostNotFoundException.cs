using System.Runtime.Serialization;

namespace dotnet_core_api.ExceptionHandling.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException()
        {
        }

        public PostNotFoundException(string? message) : base(message)
        {
        }

        public PostNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PostNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
