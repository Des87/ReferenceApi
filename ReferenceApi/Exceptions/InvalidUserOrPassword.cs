using System.Runtime.Serialization;

namespace ReferenceApi.Exceptions
{
    [Serializable]
    public class InvalidUserOrPassword : Exception
    {
        public InvalidUserOrPassword()
        {
        }

        public InvalidUserOrPassword(string? message) : base(message)
        {
        }

        public InvalidUserOrPassword(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidUserOrPassword(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}