using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CategoryJobsMVC.EFconfig;
using CategoryJobsMVC.Models;
using CategoryJobsMVC.Services;

namespace CategoryJobsMVC.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _service;
        private readonly ICategoryService _serviceCategory;

        public JobsController(IJobService service, ICategoryService serviceCategory)
        {
            _service = service;
            _serviceCategory = serviceCategory;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            List<Job> response = await _service.GetAll();
            return View(response);
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            Job job = await _service.Get(id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public async Task<IActionResult> Create()
        {
            SelectList categoryCombo = await _serviceCategory.GetAllCombo(null);
            ViewData["IdCategory"] = categoryCombo;
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategory,Description,Priority,Id,Code,Name,State,StateDelete,StateModified,CreatedDate,CreatedUserName,CreatedUserEmail,ModifiedDate,ModifiedUserName,ModifiedUserEmail")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.CreatedUserEmail = "adiaz@app.com";
                job.CreatedUserName = "Anderson Diaz";
                Job response = await _service.Save(job);
                return RedirectToAction(nameof(Index));
            }
            SelectList categoryCombo = await _serviceCategory.GetAllCombo(job.IdCategory);
            ViewData["IdCategory"] = categoryCombo;
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            Job job = await _service.Get(id);

            if (job == null)
            {
                return NotFound();
            }
            
            SelectList categoryCombo = await _serviceCategory.GetAllCombo(job.IdCategory);
            ViewData["IdCategory"] = categoryCombo;
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCategory,Description,Priority,Id,Code,Name,State,StateDelete,StateModified,CreatedDate,CreatedUserName,CreatedUserEmail,ModifiedDate,ModifiedUserName,ModifiedUserEmail")] Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                job.ModifiedUserEmail = "adiaz@app.com";
                job.ModifiedUserName = "Anderson Diaz";
                Job response = await _service.Update(id, job);
                return RedirectToAction(nameof(Index));
            }
            SelectList categoryCombo = await _serviceCategory.GetAllCombo(job.IdCategory);
            ViewData["IdCategory"] = categoryCombo;
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            Job job = await _service.Get(id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Job job = await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
