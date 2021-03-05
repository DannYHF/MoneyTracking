using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace MoneyTracking.API.Helpers.ApiExceptions
{
    public class IdentityResultException : Exception
    {
        public IdentityResultException(IdentityResult result) :
            base(string.Concat(result.Errors.Select(x=>x.Description)))
        {}
    }
}