﻿using System;
using System.Runtime.Serialization;

namespace LifeTracker.Business.CustomException
{
    [Serializable]
    public class LoginException : Exception
    {
        public LoginException() : base() { }
        public LoginException(string message): base(message) { }

        public LoginException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
