using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CategoryJobsEF.EFconfig;
using CategoryJobsEF.Models;
using CategoryJobsEF.Services;

namespace CategoryJobsEF.Controllers
{
      [Route("api/[controller]")]
      [ApiController]
      public class CategoriesController : ControllerBase
      {
            private readonly ICategoryService _service;

            public CategoriesController(ICategoryService service)
            {
                  _service = service;
            }

            // GET: api/Categories
            [HttpGet]
            public async Task<ActionResult<List<Category>>> GetAll()
            {
                  List<Category> response = await _service.GetAll();
                  return Ok(response);
            }

            // GET: api/Categories/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Category>> Get(Guid id)
            {
                  Category response = await _service.Get(id);

                  if (response == null)
                  {
                        return NotFound();
                  }

                  return response;
            }

            // POST: api/Categories
            [HttpPost]
            public async Task<ActionResult<Category>> Post(Category body)
            {
                  Category response = await _service.Save(body);
                  return Ok(response);
            }

            // PUT: api/Categories/5
            [HttpPut("{id}")]
            public async Task<IActionResult> Put(Guid id, Category body)
            {
                  if (id != body.Id)
                  {
                        return BadRequest();
                  }

                  Category response = await _service.Update(id, body);
                  return Ok(response);
            }

            // DELETE: api/Categories/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(Guid id)
            {
                  Category response = await _service.Delete(id);
                  if (response == null)
                  {
                        return NotFound();
                  }
                  return Ok("Delete Succesfull");
            }

            // DELETE: api/Categories/5
            [HttpDelete("DeleteLogic/{id}")]
            public async Task<IActionResult> DeleteLogic(Guid id)
            {
                  Category response = await _service.DeleteLogic(id);
                  if (response == null)
                  {
                        return NotFound();
                  }
                  return Ok("Delete Succesfull");
            }

            // DELETE: api/Categories
            [HttpDelete]
            public async Task<ActionResult<List<Category>>> DeleteAll()
            {
                  List<Category> response = await _service.DeleteAll();
                  return Ok(response);
            }

            // GET: api/GetAllByUser
            [HttpGet("GetAllByUser/{email}")]
            public async Task<ActionResult<List<Category>>> GetAllByUser(string email)
            {
                  List<Category> response = await _service.GetAllByUser(email);
                  return Ok(response);
            }

            // GET: api/GetAllByActive
            [HttpGet("GetAllByActive")]
            public async Task<ActionResult<List<Category>>> GetAllByActive()
            {
                  List<Category> response = await _service.GetAllByActive();
                  return Ok(response);
            }

            // GET: api/GetAllByInactive
            [HttpGet("GetAllByInactive")]
            public async Task<ActionResult<List<Category>>> GetAllByInactive()
            {
                  List<Category> response = await _service.GetAllByInactive();
                  return Ok(response);
            }

            // GET: api/GetAllByModified
            [HttpGet("GetAllByModified")]
            public async Task<ActionResult<List<Category>>> GetAllByModified()
            {
                  List<Category> response = await _service.GetAllByModified();
                  return Ok(response);
            }

            // GET: api/GetAllByNotModified
            [HttpGet("GetAllByNotModified")]
            public async Task<ActionResult<List<Category>>> GetAllByNotModified()
            {
                  List<Category> response = await _service.GetAllByNotModified();
                  return Ok(response);
            }

            // GET: api/GetAllByDelete
            [HttpGet("GetAllByDelete")]
            public async Task<ActionResult<List<Category>>> GetAllByDelete()
            {
                  List<Category> response = await _service.GetAllByDelete();
                  return Ok(response);
            }

            // GET: api/GetAllByNotDelete
            [HttpGet("GetAllByNotDelete")]
            public async Task<ActionResult<List<Category>>> GetAllByNotDelete()
            {
                  List<Category> response = await _service.GetAllByNotDelete();
                  return Ok(response);
            }

            // POST: api/GetAllOrderByName
            [HttpPost("GetAllOrderByName")]
            public async Task<ActionResult<Category>> GetAllOrderByName(FilterGetAll payload)
            {
                  List<Category> response = await _service.GetAllOrderByName(payload);
                  return Ok(response);
            }
      }
}
