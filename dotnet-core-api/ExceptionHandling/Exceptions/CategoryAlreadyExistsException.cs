using System.Runtime.Serialization;

namespace dotnet_core_api.ExceptionHandling.Exceptions
{
    public class CategoryAlreadyExistsException : Exception
    {
        public CategoryAlreadyExistsException()
        {
        }

        public CategoryAlreadyExistsException(string? message) : base(message)
        {
        }

        public CategoryAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CategoryAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
