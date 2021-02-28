using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MoneyTracking.API.Models.Response;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserInfo>();
            CreateMap<IdentityRole, Role>();
        }
    }
}