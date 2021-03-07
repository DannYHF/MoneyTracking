using System;

namespace MoneyTracking.API.Helpers.ApiExceptions
{
    public class UnsupportedImageTypeException : Exception
    {
        public UnsupportedImageTypeException() : base("Image type unsupported.")
        { }
    }
}