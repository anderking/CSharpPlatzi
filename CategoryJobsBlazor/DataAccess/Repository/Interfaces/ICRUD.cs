using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryJobsBlazor.EFconfig;
using CategoryJobsBlazor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CategoryJobsBlazor.Repository
{
      public interface ICRUDRepository<T>
      {
            Task<List<T>> GetAll();

            Task<T> Get(string id);

            Task<T> Save(T body);

            Task<T> Update(string id, T body);

            Task<T> Delete(string id);

            Task<T> DeleteLogic(string id);

            Task<List<T>> GetAllByUser(string email);

            Task<List<T>> GetAllByActive();

            Task<List<T>> GetAllByInactive();

            Task<List<T>> GetAllByModified();

            Task<List<T>> GetAllByNotModified();

            Task<List<T>> GetAllByDelete();

            Task<List<T>> GetAllByNotDelete();
      }
}
