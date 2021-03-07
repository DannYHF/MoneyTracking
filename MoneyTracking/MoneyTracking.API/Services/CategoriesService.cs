using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoneyTracking.API.Helpers.ApiExceptions;
using MoneyTracking.API.Models.Queries;
using MoneyTracking.API.Models.Responses;
using MoneyTracking.API.Services.Interfaces;
using MoneyTracking.Data;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.API.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        

        public CategoriesService(AppDbContext context,
            IMapper mapper,
            IImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<string> CreateCategory(CreateCategoryQuery query, string userId)
        {
            Category newCategory = new Category
            {
                Id = Guid.NewGuid().ToString(),
                Transactions = new List<Transaction>(),
                AppUserId = userId,
                Name = query.Name,
                ImageName = 
                    await _imageService.WriteImage(query.Icon)
            };
            var category = (await _context.Categories.AddAsync(newCategory)).Entity;
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task DeleteCategory(string categoryId)
        {
            Category category = await _context.Categories
                .SingleOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
                throw new NotFoundException(categoryId);

            _context.Categories.Remove(category);
            _imageService.DeleteImage(category.ImageName);
            await _context.SaveChangesAsync();

        }

        public async Task<Category> UpdateCategory(UpdateCategoryQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetCategoryById(string categoryId)
        {
            throw new NotImplementedException();
        }

        public List<CategoryInfo> GetCategories(bool doIncludeTransactions, string userId)
        {
            var categories = _context.Categories
                .Where(c =>c.AppUserId == userId);

            if (doIncludeTransactions)
                 categories.Include(x => x.Transactions);

            return categories.Select(category => new CategoryInfo
            {
                Id = category.Id,
                ImageName =  category.ImageName,
                Name = category.Name,
                Transactions = category.Transactions
            }).ToList();
        }
    }
}