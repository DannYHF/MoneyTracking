using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;


        public CategoriesService(AppDbContext context,
            IImageService imageService,
            IMapper mapper)
        {
            _context = context;
            _imageService = imageService;
            _mapper = mapper;
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

        public async Task<CategoryInfo> UpdateCategory(UpdateCategoryQuery query)
        {
            Category category = _context.Categories.SingleOrDefault(c=>c.Id == query.CategoryId);
            if (category == null) 
                throw new NotFoundException(query.CategoryId);

            if (!string.IsNullOrWhiteSpace(query.Name))
                category.Name = query.Name;

            if (query.Icon != null && query.Icon.Length != 0)
            {
                var imageName = await _imageService.WriteImage(query.Icon);
                 _imageService.DeleteImage(category.ImageName);
                 category.ImageName = imageName;
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryInfo>(category);
        }

        public  CategoryInfo GetCategoryById(string categoryId)
        {
            Category category = _context.Categories.SingleOrDefault(c => c.Id == categoryId);

            if (category == null)
                throw new NotFoundException(categoryId);
            
            return _mapper.Map<CategoryInfo>(category);
        }

        public List<CategoryInfo> GetCategories(string userId)
        {
            var categories = _context.Categories
                .Where(c => c.AppUserId == userId);

            return categories.Select(category => new CategoryInfo
            {
                Id = category.Id,
                ImageName =  category.ImageName,
                Name = category.Name
            }).ToList();
        }
    }
}