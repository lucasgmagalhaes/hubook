using System;
using System.Runtime.Serialization;

namespace Dort.ServiceImpl.Exceptions
{
    public class EmailSendingFailureException : Exception
    {
        public EmailSendingFailureException() : base() { }

        public EmailSendingFailureException(string? message) : base(message) { }

        public EmailSendingFailureException(string? message, Exception? innerException) : base(message, innerException) { }

        protected EmailSendingFailureException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}