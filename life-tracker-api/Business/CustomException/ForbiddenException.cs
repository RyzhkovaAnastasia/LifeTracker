using System;
using System.Runtime.Serialization;

namespace LifeTracker.Business.CustomException
{ 
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base() { }
        public ForbiddenException(string message) : base(message) { }
        public ForbiddenException(string message, Exception innerException) : base(message, innerException)
        { }
        protected ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
