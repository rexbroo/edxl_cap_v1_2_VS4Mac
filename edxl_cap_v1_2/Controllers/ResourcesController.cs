using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using edxl_cap_v1_2.Data;
using edxl_cap_v1_2.Models;
using edxl_cap_v1_2.Models.ContentViewModels;

namespace edxl_cap_v1_2.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Areas
        public ActionResult ResourceSelect()
        {
            var vm = new ResourceViewModel();

            //Load the Identifiers property which will be used to build the SELECT element
            vm.Alert_Identifiers = _context.EdxlCapMsg
                                    .Select(x => new SelectListItem
                                    {
                                        Value = x.AlertIndex.ToString(),
                                        Text = x.Alert_Identifier
                                    }).ToList();

            //Load the Resources
            vm.Resources = _context.EdxlCapMsg.Select(a => new ResourceVm
            {
                ResourceIndex = a.ResourceIndex,
                Alert_Identifier = a.Alert_Identifier
            }).ToList();
            return View(vm);
        }

        public IActionResult PickResource(Resource obj, int? SelectedAlertIndex)
        {
            if (SelectedAlertIndex.HasValue)
            {
                ViewBag.Message = "Resource loaded successfully";
            }
            return View(_context.Resource.Where(x => x.ResourceIndex == SelectedAlertIndex));
        }

        // GET: resources
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resource.ToListAsync());
        }

        [HttpPost]
        public IActionResult Index(Resource obj, int? SelectedAlertIndex)
        {
            if (SelectedAlertIndex.HasValue)
            {
                ViewBag.Message = "Resource loaded successfully";
            }
            return View(_context.Resource.Where(x => x.ResourceIndex == SelectedAlertIndex));
        }

        // GET: Resources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource
                //.Include(e => e.Elements)
                //    .ThenInclude(d => d.DataCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ResourceIndex == id);

            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }
        // GET: Resources/Details/5
        public async Task<IActionResult> _DetailsResource(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource
                //.Include(e => e.Elements)
                //    .ThenInclude(d => d.DataCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ResourceIndex == id);

            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Resources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResourceIndex,ResourceDesc,MimeType,Size,Uri,DerefUri,Digest,Info_Alert_Identifier,DataCategory_Id")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Resources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource.SingleOrDefaultAsync(m => m.ResourceIndex == id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: Resources/Edit/5
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
            var resourceToUpdate = await _context.Resource.SingleOrDefaultAsync(r => r.ResourceIndex == id);
            if (await TryUpdateModelAsync<Resource>(
                resourceToUpdate,
                "",
                r => r.ResourceIndex, r => r.ResourceDesc, r => r.MimeType, r => r.Size, r => r.Uri, r => r.DerefUri, r => r.Info_Alert_Identifier, r => r.DataCategory_Id))
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
            return View(resourceToUpdate);
        }

        // GET: Resources/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ResourceIndex == id);
            if (resource == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resource = await _context.Resource
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ResourceIndex == id);
            if (resource == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Resource.Remove(resource);
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
