using System;
using System.Collections.Generic;
using System.Text;

namespace LifeTracker.Business.CustomException
{
    public class RegistrationException: Exception
    {
        public RegistrationException(): base() { }
        public RegistrationException(string message): base(message) { }
    }
}
