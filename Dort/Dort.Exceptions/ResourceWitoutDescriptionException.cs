using System;
using System.Runtime.Serialization;

namespace Dort.Exceptions
{
    public class ResourceWitoutDescriptionException : Exception
    {
        /// <summary>
        /// Initialize this exception with a default message.
        /// <br/>
        /// <b>No description for resource was informed in selected culture.</b>
        /// </summary>
        public ResourceWitoutDescriptionException() : base("No description for resource was informed in selected culture.") { }

        public ResourceWitoutDescriptionException(string? message) : base(message) { }

        public ResourceWitoutDescriptionException(string? message, Exception? innerException) : base(message, innerException) { }

        protected ResourceWitoutDescriptionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
