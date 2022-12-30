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
      public class JobsController : ControllerBase
      {
            private readonly IJobService _service;

            public JobsController(IJobService service)
            {
                  _service = service;
            }

            // GET: api/Jobs
            [HttpGet]
            public async Task<ActionResult<List<Job>>> GetAll()
            {
                  List<Job> response = await _service.GetAll();
                  return Ok(response);
            }

            // GET: api/Jobs/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Job>> Get(Guid id)
            {
                  Job response = await _service.Get(id);

                  if (response == null)
                  {
                        return NotFound();
                  }

                  return response;
            }

            // POST: api/Jobs
            [HttpPost]
            public async Task<ActionResult<Job>> Post(Job body)
            {
                  Job response = await _service.Save(body);
                  return Ok(response);
            }

            // PUT: api/Jobs/5
            [HttpPut("{id}")]
            public async Task<IActionResult> Put(Guid id, Job body)
            {
                  if (id != body.Id)
                  {
                        return BadRequest();
                  }

                  Job response = await _service.Update(id, body);
                  return Ok(response);
            }

            // DELETE: api/Jobs/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(Guid id)
            {
                  Job response = await _service.Delete(id);
                  if (response == null)
                  {
                        return NotFound();
                  }
                  return Ok("Delete Succesfull");
            }

            // DELETE: api/Jobs/5
            [HttpDelete("DeleteLogic/{id}")]
            public async Task<IActionResult> DeleteLogic(Guid id)
            {
                  Job response = await _service.DeleteLogic(id);
                  if (response == null)
                  {
                        return NotFound();
                  }
                  return Ok("Delete Succesfull");
            }

            // DELETE: api/Jobs
            [HttpDelete]
            public async Task<ActionResult<List<Job>>> DeleteAll()
            {
                  List<Job> response = await _service.DeleteAll();
                  return Ok(response);
            }

            // GET: api/GetAllByUser
            [HttpGet("GetAllByUser/{email}")]
            public async Task<ActionResult<List<Job>>> GetAllByUser(string email)
            {
                  List<Job> response = await _service.GetAllByUser(email);
                  return Ok(response);
            }

            // GET: api/GetAllByActive
            [HttpGet("GetAllByActive")]
            public async Task<ActionResult<List<Job>>> GetAllByActive()
            {
                  List<Job> response = await _service.GetAllByActive();
                  return Ok(response);
            }

            // GET: api/GetAllByInactive
            [HttpGet("GetAllByInactive")]
            public async Task<ActionResult<List<Job>>> GetAllByInactive()
            {
                  List<Job> response = await _service.GetAllByInactive();
                  return Ok(response);
            }

            // GET: api/GetAllByModified
            [HttpGet("GetAllByModified")]
            public async Task<ActionResult<List<Job>>> GetAllByModified()
            {
                  List<Job> response = await _service.GetAllByModified();
                  return Ok(response);
            }

            // GET: api/GetAllByNotModified
            [HttpGet("GetAllByNotModified")]
            public async Task<ActionResult<List<Job>>> GetAllByNotModified()
            {
                  List<Job> response = await _service.GetAllByNotModified();
                  return Ok(response);
            }

            // GET: api/GetAllByDelete
            [HttpGet("GetAllByDelete")]
            public async Task<ActionResult<List<Job>>> GetAllByDelete()
            {
                  List<Job> response = await _service.GetAllByDelete();
                  return Ok(response);
            }

            // GET: api/GetAllByNotDelete
            [HttpGet("GetAllByNotDelete")]
            public async Task<ActionResult<List<Job>>> GetAllByNotDelete()
            {
                  List<Job> response = await _service.GetAllByNotDelete();
                  return Ok(response);
            }

            // POST: api/GetAllOrderByName
            [HttpPost("GetAllOrderByName")]
            public async Task<ActionResult<Job>> GetAllOrderByName(FilterGetAll payload)
            {
                  List<Job> response = await _service.GetAllOrderByName(payload);
                  return Ok(response);
            }
      }
}
