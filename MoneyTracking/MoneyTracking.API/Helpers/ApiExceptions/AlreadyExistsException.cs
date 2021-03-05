using System;

namespace MoneyTracking.API.Helpers.ApiExceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message) : base(message)
        { }
    }
}