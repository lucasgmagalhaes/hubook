using System;
using System.Runtime.Serialization;

namespace Dort.I18n.Exceptions
{
    public class LanguageException : Exception
    {
        public LanguageException() : base() { }

        public LanguageException(string? message) : base(message) { }

        public LanguageException(string? message, Exception? innerException) : base(message, innerException) { }

        protected LanguageException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}