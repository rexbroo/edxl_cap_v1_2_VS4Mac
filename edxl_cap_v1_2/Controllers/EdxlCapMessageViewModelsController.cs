using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using edxl_cap_v1_2.Data;
using edxl_cap_v1_2.Models.ContentViewModels;

namespace edxl_cap_v1_2.Controllers
{
    public class EdxlCapMessageViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EdxlCapMessageViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EdxlCapMessageViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.EdxlCapMessageViewModel.ToListAsync());
        }

        // GET: EdxlCapMessageViewModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edxlCapMessageViewModel = await _context.EdxlCapMessageViewModel
                .SingleOrDefaultAsync(m => m.Alert_Identifier == id);
            if (edxlCapMessageViewModel == null)
            {
                return NotFound();
            }

            return View(edxlCapMessageViewModel);
        }

        // GET: EdxlCapMessageViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EdxlCapMessageViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Alert_Identifier")] EdxlCapMessageViewModel edxlCapMessageViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edxlCapMessageViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(edxlCapMessageViewModel);
        }

        // GET: EdxlCapMessageViewModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edxlCapMessageViewModel = await _context.EdxlCapMessageViewModel.SingleOrDefaultAsync(m => m.Alert_Identifier == id);
            if (edxlCapMessageViewModel == null)
            {
                return NotFound();
            }
            return View(edxlCapMessageViewModel);
        }

        // POST: EdxlCapMessageViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Alert_Identifier")] EdxlCapMessageViewModel edxlCapMessageViewModel)
        {
            if (id != edxlCapMessageViewModel.Alert_Identifier)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edxlCapMessageViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdxlCapMessageViewModelExists(edxlCapMessageViewModel.Alert_Identifier))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(edxlCapMessageViewModel);
        }

        // GET: EdxlCapMessageViewModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edxlCapMessageViewModel = await _context.EdxlCapMessageViewModel
                .SingleOrDefaultAsync(m => m.Alert_Identifier == id);
            if (edxlCapMessageViewModel == null)
            {
                return NotFound();
            }

            return View(edxlCapMessageViewModel);
        }

        // POST: EdxlCapMessageViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var edxlCapMessageViewModel = await _context.EdxlCapMessageViewModel.SingleOrDefaultAsync(m => m.Alert_Identifier == id);
            _context.EdxlCapMessageViewModel.Remove(edxlCapMessageViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EdxlCapMessageViewModelExists(string id)
        {
            return _context.EdxlCapMessageViewModel.Any(e => e.Alert_Identifier == id);
        }
    }
}
