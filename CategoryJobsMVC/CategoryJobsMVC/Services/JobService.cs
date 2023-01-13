using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryJobsMVC.EFconfig;
using CategoryJobsMVC.Models;
using CategoryJobsMVC.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CategoryJobsMVC.Services
{

      public interface IJobService : ICRUDService<Job>
      {
            Task<List<Job>> GetAllOrderByName(FilterGetAll payload);
            Task<List<Job>> DeleteAll();
            Task<List<Job>> SetRelations(List<Job> items);
      }

      public class JobService : IJobService
      {
            private readonly EFconfigContext _context;
            private readonly ILogger<JobService> _logger;
            private readonly ICategoryService _serviceCategory;

            public JobService(EFconfigContext context, ICategoryService serviceCategory, ILogger<JobService> logger)
            {
                  _context = context;
                  _logger = logger;
                  _serviceCategory = serviceCategory;
            }

            public async Task<List<Job>> GetAll()
            {
                  List<Job> items = new List<Job>();

                  try
                  {
                        items = await _context.Jobs.ToListAsync();
                        items = await SetRelations(items);
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<Job> Get(Guid id)
            {
                  Job item;

                  try
                  {
                        item = await _context.Jobs.FindAsync(id);
                        item.Category = await _serviceCategory.Get(item.IdCategory);
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return item;
            }

            public async Task<Job> Save(Job body)
            {
                  try
                  {
                        body.Id = Guid.NewGuid();
                        body.CreatedDate = DateTime.Now;
                        body.StateModified = false;
                        body.StateDelete = false;
                        List<Job> items = await GetAll();
                        long.TryParse(items.Where(w => !string.IsNullOrWhiteSpace(w.Code)).Select(s => s.Code).Max(), out long codeMax);
                        body.Code = Tools.ConsecutiveText(codeMax + 1);
                        _context.Add(body);
                        await _context.SaveChangesAsync();
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return body;
            }

            public async Task<Job> Update(Guid id, Job body)
            {
                  Job item;

                  try
                  {
                        item = _context.Jobs.Find(id);

                        if (item != null)
                        {
                              item.Name = body.Name;
                              item.IdCategory = body.IdCategory;
                              item.Priority = body.Priority;
                              item.Description = body.Description;
                              item.State = body.State;
                              item.ModifiedDate = DateTime.Now;
                              item.ModifiedUserName = body.ModifiedUserName;
                              item.ModifiedUserEmail = body.ModifiedUserEmail;
                              item.StateModified = true;
                              _context.Update(item);
                              await _context.SaveChangesAsync();
                        }
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return item;
            }

            public async Task<Job> Delete(Guid id)
            {
                  Job item;

                  try
                  {
                        item = _context.Jobs.Find(id);

                        if (item != null)
                        {
                              _context.Remove(item);
                              await _context.SaveChangesAsync();
                        }
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return item;
            }

            public async Task<Job> DeleteLogic(Guid id)
            {
                  Job item;

                  try
                  {
                        item = _context.Jobs.Find(id);

                        if (item != null)
                        {
                              item.StateDelete = true;
                              _context.Update(item);
                              await _context.SaveChangesAsync();
                        }
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return item;
            }

            public async Task<List<Job>> DeleteAll()
            {
                  List<Job> items = await GetAll();
                  List<Job> itemsDelete = new List<Job>();

                  try
                  {
                        foreach (var item in items)
                        {
                              if (item != null)
                              {
                                    _context.Remove(item);
                                    await _context.SaveChangesAsync();
                                    itemsDelete.Add(item);
                              }
                        }
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return itemsDelete;
            }

            public async Task<List<Job>> GetAllByUser(string email)
            {
                  List<Job> items = new List<Job>();

                  try
                  {
                        items = await _context.Jobs.Where(x => x.CreatedUserEmail == email).ToListAsync();
                        items = await SetRelations(items);
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Job>> GetAllByActive()
            {
                  List<Job> items = new List<Job>();

                  try
                  {
                        items = await _context.Jobs.Where(x => x.State == true).ToListAsync();
                        items = await SetRelations(items);
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Job>> GetAllByInactive()
            {
                  List<Job> items = new List<Job>();

                  try
                  {
                        items = await _context.Jobs.Where(x => x.State == false).ToListAsync();
                        items = await SetRelations(items);
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Job>> GetAllByModified()
            {
                  List<Job> items = new List<Job>();

                  try
                  {
                        items = await _context.Jobs.Where(x => x.StateModified == true).ToListAsync();
                        items = await SetRelations(items);
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Job>> GetAllByNotModified()
            {
                  List<Job> items = new List<Job>();

                  try
                  {
                        items = await _context.Jobs.Where(x => x.StateModified == false).ToListAsync();
                        items = await SetRelations(items);
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Job>> GetAllByDelete()
            {
                  List<Job> items = new List<Job>();

                  try
                  {
                        items = await _context.Jobs.Where(x => x.StateDelete == true).ToListAsync();
                        items = await SetRelations(items);
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Job>> GetAllByNotDelete()
            {
                  List<Job> items = new List<Job>();

                  try
                  {
                        items = await _context.Jobs.Where(x => x.StateDelete == false).ToListAsync();
                        items = await SetRelations(items);
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Job>> GetAllOrderByName(FilterGetAll payload)
            {
                  List<Job> items = new List<Job>();

                  try
                  {
                        switch (payload.Filter)
                        {
                              case "GetAllByUser":
                                    items = await GetAllByUser(payload.CreatedUserEmail);
                                    break;
                              case "GetAllByActive":
                                    items = await GetAllByActive();
                                    break;
                              case "GetAllByInactive":
                                    items = await GetAllByInactive();
                                    break;
                              case "GetAllByModified":
                                    items = await GetAllByModified();
                                    break;
                              case "GetAllByNotModified":
                                    items = await GetAllByNotModified();
                                    break;
                              case "GetAllByDelete":
                                    items = await GetAllByDelete();
                                    break;
                              case "GetAllByNotDelete":
                                    items = await GetAllByNotDelete();
                                    break;
                              default:
                                    items = await GetAll();
                                    break;
                        }
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

                  return items.OrderBy(o => o.Name).ToList();
            }

            public async Task<SelectList> GetAllCombo(Guid? Id)
            {
                  SelectList items;

                  try
                  {
                        if (Id != null)
                        {
                              items = new SelectList((await GetAllByActive()).OrderBy(o => o.Name).ToList(), "Id", "Name", Id);
                        }
                        else
                        {
                              items = new SelectList((await GetAllByActive()).OrderBy(o => o.Name).ToList(), "Id", "Name");
                        }
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"JobService: {e.Message}");
                        throw;
                  }

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
