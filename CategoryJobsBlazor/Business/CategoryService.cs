using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryJobsBlazor.EFconfig;
using CategoryJobsBlazor.Models;
using CategoryJobsBlazor.Repository;
using CategoryJobsBlazor.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CategoryJobsBlazor.Business
{
      public interface ICategoryService : ICRUDService<Category>
      {
            Task<List<Category>> GetAllOrderByName(FilterGetAll payload);
            Task<List<Category>> DeleteAll();
      }

      public class CategoryService : ICategoryService
      {
            private readonly ICategoryRepository _categoryRepository;

            public CategoryService(EFconfigContext context, ILogger<CategoryRepository> logger)
            {
                  _categoryRepository = new CategoryRepository(context, logger);
            }

            public async Task<List<Category>> GetAll()
            {
                  List<Category> items = new List<Category>();
                  items = await _categoryRepository.GetAll();
                  return items;
            }

            public async Task<Category> Get(string id)
            {
                  Category item;
                  item = await _categoryRepository.Get(id);
                  return item;
            }

            public async Task<Category> Save(Category body)
            {
                  Category item = await _categoryRepository.Save(body);
                  return item;
            }

            public async Task<Category> Update(string id, Category body)
            {
                  Category item = await _categoryRepository.Update(id, body);
                  return item;
            }

            public async Task<Category> Delete(string id)
            {
                  Category item = await _categoryRepository.Delete(id);
                  return item;
            }

            public async Task<Category> DeleteLogic(string id)
            {
                  Category item = await _categoryRepository.DeleteLogic(id);
                  return item;
            }

            public async Task<List<Category>> DeleteAll()
            {
                  List<Category> items = await _categoryRepository.DeleteAll();
                  return items;
            }

            public async Task<List<Category>> GetAllByUser(string email)
            {
                  List<Category> items = new List<Category>();
                  items = await _categoryRepository.GetAllByUser(email);
                  return items;
            }

            public async Task<List<Category>> GetAllByActive()
            {
                  List<Category> items = new List<Category>();
                  items = await _categoryRepository.GetAllByActive();
                  return items;
            }

            public async Task<List<Category>> GetAllByInactive()
            {
                  List<Category> items = new List<Category>();
                  items = await _categoryRepository.GetAllByInactive();
                  return items;
            }

            public async Task<List<Category>> GetAllByModified()
            {
                  List<Category> items = new List<Category>();
                  items = await _categoryRepository.GetAllByModified();
                  return items;
            }

            public async Task<List<Category>> GetAllByNotModified()
            {
                  List<Category> items = new List<Category>();
                  items = await _categoryRepository.GetAllByNotModified();
                  return items;
            }

            public async Task<List<Category>> GetAllByDelete()
            {
                  List<Category> items = new List<Category>();
                  items = await _categoryRepository.GetAllByDelete();
                  return items;
            }

            public async Task<List<Category>> GetAllByNotDelete()
            {
                  List<Category> items = new List<Category>();
                  items = await _categoryRepository.GetAllByNotDelete();
                  return items;
            }

            public async Task<List<Category>> GetAllOrderByName(FilterGetAll payload)
            {
                  List<Category> items = new List<Category>();
                  items = await _categoryRepository.GetAllOrderByName(payload);
                  return items;
            }
      }
}
