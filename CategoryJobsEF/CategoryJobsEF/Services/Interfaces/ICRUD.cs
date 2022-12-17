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

      public interface ICRUDService
      {
            Task<List<Category>> GetAll();

            Task<Category> Get(Guid id);

            Task<Category> Save(Category body);

            Task<Category> Update(Guid id, Category body);

            Task<Category> Delete(Guid id);

            Task<Category> DeleteLogic(Guid id);

            Task<List<Category>> GetAllByUser(string email);

            Task<List<Category>> GetAllByActive();

            Task<List<Category>> GetAllByInactive();

            Task<List<Category>> GetAllByModified();

            Task<List<Category>> GetAllByNotModified();

            Task<List<Category>> GetAllByDelete();

            Task<List<Category>> GetAllByNotDelete();
      }
}
