using System;

namespace MoneyTracking.API.Helpers.ApiExceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(string parameterName) : base($"{parameterName} not found.")
        { }
    }
}