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
    public class AreasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Areas
        public ActionResult AreaSelect()
        {
            var vm = new AreaViewModel();

            //Load the Identifiers property which will be used to build the SELECT element
            vm.Alert_Identifiers = _context.EdxlCapMsg
                                    .Select(x => new SelectListItem
                                    {
                                        Value = x.AlertIndex.ToString(),
                                        Text = x.Alert_Identifier
                                    }).ToList();

            //Load the Areas
            vm.Areas = _context.EdxlCapMsg.Select(a => new AreaVm
            {
                AreaIndex = a.AreaIndex,
                //Alert_Identifier = a.Alert_Identifier
            }).ToList();
            return View(vm);
        }

        // GET: Areas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Area.ToListAsync());
        }

        [HttpPost]
        public IActionResult Index(Area obj, int? SelectedAlertIndex)
        {
            if (SelectedAlertIndex.HasValue)
            {
                ViewBag.Message = "Area loaded successfully";
            }
            return View(_context.Area.Where(x => x.AreaIndex == SelectedAlertIndex));
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area
                //.Include(e => e.Elements)
                //    .ThenInclude(d => d.DataCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.AreaIndex == id);

            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AreaIndex,AreaDesc,Polygon,Circle,Geocode,Altitude,Ceiling,DataCategory_Id")] Area area)
        {
            if (ModelState.IsValid)
            {
                _context.Add(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(area);
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area.SingleOrDefaultAsync(m => m.AreaIndex == id);
            if (area == null)
            {
                return NotFound();
            }
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var areaToUpdate = await _context.Area.SingleOrDefaultAsync(s => s.AreaIndex == id);
            if (await TryUpdateModelAsync<Area>(
                areaToUpdate,
                "",
                s => s.AreaIndex, s => s.AreaDesc, s => s.Polygon, s => s.Circle, s => s.Geocode, s => s.Altitude, s => s.Ceiling, s => s.DataCategory_Id))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(areaToUpdate);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.AreaIndex == id);
            if (area == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var area = await _context.Area
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.AreaIndex == id);
            if (area == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Area.Remove(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}
