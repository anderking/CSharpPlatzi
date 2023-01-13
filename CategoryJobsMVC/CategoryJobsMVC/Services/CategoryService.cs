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

      public interface ICategoryService : ICRUDService<Category>
      {
            Task<List<Category>> GetAllOrderByName(FilterGetAll payload);
            Task<List<Category>> DeleteAll();
      }

      public class CategoryService : ICategoryService
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
                  catch (Exception e)
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
                  catch (Exception e)
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
                        body.StateModified = false;
                        body.StateDelete = false;
                        List<Category> items = await GetAll();
                        long.TryParse(items.Where(w => !string.IsNullOrWhiteSpace(w.Code)).Select(s => s.Code).Max(), out long codeMax);
                        body.Code = Tools.ConsecutiveText(codeMax + 1);
                        _context.Add(body);
                        await _context.SaveChangesAsync();
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return body;
            }

            public async Task<Category> Update(Guid id, Category body)
            {
                  Category item;

                  try
                  {
                        item = _context.Categories.Find(id);

                        if (item != null)
                        {
                              item.Name = body.Name;
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
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return item;
            }

            public async Task<Category> Delete(Guid id)
            {
                  Category item;

                  try
                  {
                        item = _context.Categories.Find(id);

                        if (item != null)
                        {
                              _context.Remove(item);
                              await _context.SaveChangesAsync();
                        }
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return item;
            }

            public async Task<Category> DeleteLogic(Guid id)
            {
                  Category item;

                  try
                  {
                        item = _context.Categories.Find(id);

                        if (item != null)
                        {
                              item.StateDelete = true;
                              _context.Update(item);
                              await _context.SaveChangesAsync();
                        }
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return item;
            }

            public async Task<List<Category>> DeleteAll()
            {
                  List<Category> items = await GetAll();
                  List<Category> itemsDelete = new List<Category>();

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
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return itemsDelete;
            }

            public async Task<List<Category>> GetAllByUser(string email)
            {
                  List<Category> items = new List<Category>();

                  try
                  {
                        items = await _context.Categories.Where(x => x.CreatedUserEmail == email).ToListAsync();
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Category>> GetAllByActive()
            {
                  List<Category> items = new List<Category>();

                  try
                  {
                        items = await _context.Categories.Where(x => x.State == true).ToListAsync();
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Category>> GetAllByInactive()
            {
                  List<Category> items = new List<Category>();

                  try
                  {
                        items = await _context.Categories.Where(x => x.State == false).ToListAsync();
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Category>> GetAllByModified()
            {
                  List<Category> items = new List<Category>();

                  try
                  {
                        items = await _context.Categories.Where(x => x.StateModified == true).ToListAsync();
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Category>> GetAllByNotModified()
            {
                  List<Category> items = new List<Category>();

                  try
                  {
                        items = await _context.Categories.Where(x => x.StateModified == false).ToListAsync();
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Category>> GetAllByDelete()
            {
                  List<Category> items = new List<Category>();

                  try
                  {
                        items = await _context.Categories.Where(x => x.StateDelete == true).ToListAsync();
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Category>> GetAllByNotDelete()
            {
                  List<Category> items = new List<Category>();

                  try
                  {
                        items = await _context.Categories.Where(x => x.StateDelete == false).ToListAsync();
                  }
                  catch (Exception e)
                  {
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return items;
            }

            public async Task<List<Category>> GetAllOrderByName(FilterGetAll payload)
            {
                  List<Category> items = new List<Category>();

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
                        _logger.LogInformation($"CategoryService: {e.Message}");
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
                        _logger.LogInformation($"CategoryService: {e.Message}");
                        throw;
                  }

                  return items;
            }
      }
}
