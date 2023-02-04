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
      public interface IJobService : ICRUDService<Job>
      {
            Task<List<Job>> GetAllOrderByName(FilterGetAll payload);
            Task<List<Job>> DeleteAll();
            Task<List<Job>> SetRelations(List<Job> items);
      }

      public class JobService : IJobService
      {
            private readonly IJobRepository _jobRepository;
            private readonly ICategoryService _serviceCategory;

            public JobService(EFconfigContext context, ICategoryService serviceCategory, ILogger<JobRepository> logger)
            {
                  _jobRepository = new JobRepository(context, logger);
                  _serviceCategory = serviceCategory;
            }

            public async Task<List<Job>> GetAll()
            {
                  List<Job> items = new List<Job>();
                  items = await _jobRepository.GetAll();
                  items = await SetRelations(items);
                  return items;
            }

            public async Task<Job> Get(string id)
            {
                  Job item;
                  item = await _jobRepository.Get(id);
                  item.Category = await _serviceCategory.Get(item.IdCategory);
                  return item;
            }

            public async Task<Job> Save(Job body)
            {
                  Job item = await _jobRepository.Save(body);
                  return item;
            }

            public async Task<Job> Update(string id, Job body)
            {
                  Job item = await _jobRepository.Update(id, body);
                  return item;
            }

            public async Task<Job> Delete(string id)
            {
                  Job item = await _jobRepository.Delete(id);
                  return item;
            }

            public async Task<Job> DeleteLogic(string id)
            {
                  Job item = await _jobRepository.DeleteLogic(id);
                  return item;
            }

            public async Task<List<Job>> DeleteAll()
            {
                  List<Job> items = await _jobRepository.DeleteAll();
                  return items;
            }

            public async Task<List<Job>> GetAllByUser(string email)
            {
                  List<Job> items = new List<Job>();
                  items = await _jobRepository.GetAllByUser(email);
                  items = await SetRelations(items);
                  return items;
            }

            public async Task<List<Job>> GetAllByActive()
            {
                  List<Job> items = new List<Job>();
                  items = await _jobRepository.GetAllByActive();
                  items = await SetRelations(items);
                  return items;
            }

            public async Task<List<Job>> GetAllByInactive()
            {
                  List<Job> items = new List<Job>();
                  items = await _jobRepository.GetAllByInactive();
                  items = await SetRelations(items);
                  return items;
            }

            public async Task<List<Job>> GetAllByModified()
            {
                  List<Job> items = new List<Job>();
                  items = await _jobRepository.GetAllByModified();
                  items = await SetRelations(items);
                  return items;
            }

            public async Task<List<Job>> GetAllByNotModified()
            {
                  List<Job> items = new List<Job>();
                  items = await _jobRepository.GetAllByNotModified();
                  items = await SetRelations(items);
                  return items;
            }

            public async Task<List<Job>> GetAllByDelete()
            {
                  List<Job> items = new List<Job>();
                  items = await _jobRepository.GetAllByDelete();
                  items = await SetRelations(items);
                  return items;
            }

            public async Task<List<Job>> GetAllByNotDelete()
            {
                  List<Job> items = new List<Job>();
                  items = await _jobRepository.GetAllByNotDelete();
                  items = await SetRelations(items);
                  return items;
            }

            public async Task<List<Job>> GetAllOrderByName(FilterGetAll payload)
            {
                  List<Job> items = new List<Job>();
                  items = await _jobRepository.GetAllOrderByName(payload);
                  items = await SetRelations(items);
                  return items;
            }

            public async Task<List<Job>> SetRelations(List<Job> items)
            {
                  List<Category> categories = await _serviceCategory.GetAll();
                  foreach (var item in items)
                  {
                        Category category = categories.FirstOrDefault(c => c.Id == item.IdCategory);
                        item.Category = category;
                  }
                  return items;
            }
      }
}
