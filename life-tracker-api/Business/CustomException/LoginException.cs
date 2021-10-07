using System;

namespace LifeTracker.Business.CustomException
{
    public class LoginException : Exception
    {
        public LoginException() : base() { }
        public LoginException(string message): base(message) { }
    }
}
