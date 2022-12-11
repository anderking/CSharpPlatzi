using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryJobsEF.EFconfig;
using CategoryJobsEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CategoryJobsEF.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly EFconfigContext _context;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(EFconfigContext context, ILogger<CategoryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Category>> GetAll()
        {
            List<Category> items = new List<Category>();

            try
            {
                items = await _context.Categories.ToListAsync();
            }
            catch(Exception e)
            {
                _logger.LogInformation($"CategoryService: {e.Message}");
                throw;
            }

            return items;
        }

        public async Task<Category> Get(Guid id)
        {
            Category item;
            
            try
            {
                item = await _context.Categories.FindAsync(id);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"CategoryService: {e.Message}");
                throw;
            }

            return item;
        }

        public async Task<Category> Save(Category body)
        {   
            try
            {
                body.Id = Guid.NewGuid();
                body.CreatedDate = DateTime.Now;
                _context.Add(body);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                _logger.LogInformation($"CategoryService: {e.Message}");
                throw;
            }

            return body;
        }

        public async Task<Category> Update(Guid id, Category body)
        {
            Category category;
            
            try
            {
                category = _context.Categories.Find(id);

                if(category != null)
                {
                    category.Name = body.Name;
                    category.Description = body.Description;
                    category.ModifedDate = DateTime.Now;
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception e)
            {
                _logger.LogInformation($"CategoryService: {e.Message}");
                throw;
            }

            return category;
        }

        public async Task<Category> Delete(Guid id)
        {
            Category category;

            try
            {
                category = _context.Categories.Find(id);

                if(category != null)
                {
                    _context.Remove(category);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception e)
            {
                _logger.LogInformation($"CategoryService: {e.Message}");
                throw;
            }

            return category;
        }
    }

    public interface ICategoryService
    {
        Task<List<Category>> GetAll();

        Task<Category> Get(Guid id);

        Task<Category> Save(Category body);

        Task<Category> Update(Guid id, Category body);

        Task<Category> Delete(Guid id);
    }
}
