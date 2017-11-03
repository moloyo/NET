using System;
using System.Runtime.Serialization;

namespace Util {
    public class LoginException : System.Exception {
        public LoginException() : base() { }

        public LoginException(String message) : base(message) { }

        public LoginException(String message, Exception innerException) : base(message, innerException) { }

        protected LoginException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class NotFound : System.Exception {
        public NotFound() : base("The element was not found") { }

        public NotFound(String message) : base(message) { }

        public NotFound(String message, Exception innerException) : base(message, innerException) { }

        protected NotFound(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
