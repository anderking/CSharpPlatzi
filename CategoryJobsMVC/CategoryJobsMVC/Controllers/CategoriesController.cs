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
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
                _service = service;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            List<Category> response = await _service.GetAll();
            return View(response);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            Category category = await _service.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Id,Code,Name,State,StateDelete,StateModified,CreatedDate,CreatedUserName,CreatedUserEmail,ModifiedDate,ModifiedUserName,ModifiedUserEmail")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreatedUserEmail = "adiaz@app.com";
                category.CreatedUserName = "Anderson Diaz";
                Category response = await _service.Save(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            Category category = await _service.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Description,Id,Code,Name,State,StateDelete,StateModified,CreatedDate,CreatedUserName,CreatedUserEmail,ModifiedDate,ModifiedUserName,ModifiedUserEmail")] Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                category.ModifiedUserEmail = "adiaz@app.com";
                category.ModifiedUserName = "Anderson Diaz";
                Category response = await _service.Update(id, category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            Category category = await _service.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Category category = await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
