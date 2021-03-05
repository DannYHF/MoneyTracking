using System;

namespace MoneyTracking.API.Helpers.ApiExceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string message) : base(message)
        { }
    }
}