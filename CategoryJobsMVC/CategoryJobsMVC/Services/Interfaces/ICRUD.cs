using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryJobsMVC.EFconfig;
using CategoryJobsMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CategoryJobsMVC.Services
{

      public interface ICRUDService<T>
      {
            Task<List<T>> GetAll();

            Task<T> Get(Guid id);

            Task<T> Save(T body);

            Task<T> Update(Guid id, T body);

            Task<T> Delete(Guid id);

            Task<T> DeleteLogic(Guid id);

            Task<List<T>> GetAllByUser(string email);

            Task<List<T>> GetAllByActive();

            Task<List<T>> GetAllByInactive();

            Task<List<T>> GetAllByModified();

            Task<List<T>> GetAllByNotModified();

            Task<List<T>> GetAllByDelete();

            Task<List<T>> GetAllByNotDelete();

            Task<SelectList> GetAllCombo(Guid? Id);
      }
}
