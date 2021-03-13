using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MoneyTracking.API.Models;
using MoneyTracking.API.Models.Responses;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserInfo>();
            CreateMap<Category, CategoryInfo>();
            CreateMap<Transaction, TransactionInfo>();
            CreateMap<IdentityRole, Role>();
        }
    }
}