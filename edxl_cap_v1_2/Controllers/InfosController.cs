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
    public class InfosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InfosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alerts
        public ActionResult InfoSelect()
        {
            var vm = new InfoViewModel();

            //Load the Identifiers property which will be used to build the SELECT element
            vm.Alert_Identifiers = _context.EdxlCapMsg
                                    .Select(x => new SelectListItem
                                    {
                                        Value = x.InfoIndex.ToString(),
                                        Text = x.Alert_Identifier
                                    }).ToList();

            //Load the Infos
            vm.Infos = _context.EdxlCapMsg.Select(a => new InfoVm
            {
                InfoIndex = a.InfoIndex,
                //Alert_Identifier = a.Alert_Identifier
            }).ToList();
            return View(vm);
        }

        // GET: Infos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Info.ToListAsync());
        }

        [HttpPost]
        public IActionResult Index(Info obj, int? SelectedAlertIndex)
        {
            if (SelectedAlertIndex.HasValue)
            {
                ViewBag.Message = "Info loaded successfully";
            }
            return View(_context.Info.Where(x => x.InfoIndex == SelectedAlertIndex));
        }

        // GET: Infos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Info
                //.Include(e => e.Elements)
                //    .ThenInclude(d => d.DataCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.InfoIndex == id);

            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // GET: Infos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Infos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("InfoIndex,Language,Category,Event,ResponseType,Urgency,Certainty,Severity,Audience,EventCode,Effective,Onset,Expires,SenderName,Headline,Description,Instruction,Web,Contact,Parameter,DataCategory_Id")] Info info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(info);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(info);
        }

        // GET: Infos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Info.SingleOrDefaultAsync(m => m.InfoIndex == id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }

        // POST: Infos/Edit/5
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
            var infoToUpdate = await _context.Info.SingleOrDefaultAsync(s => s.InfoIndex == id);
            if (await TryUpdateModelAsync<Info>(
                infoToUpdate,
                "",
                i => i.InfoIndex, i => i.Language, i => i.Category, i => i.Event, i => i.ResponseType, i => 
                i.Urgency, i => i.Certainty, i => i.Severity, i => i.Audience, i => i.EventCode, i => i.Effective, 
                i => i.Onset, i => i.Expires, i => i.SenderName, i => i.Headline, i => i.Description, i => i.Instruction, 
                i => i.Web, i => i.Contact, i => i.Parameter, i => i.DataCategory_Id))
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
            return View(infoToUpdate);
        }

        // GET: Infos/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Info
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.InfoIndex == id);
            if (info == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(info);
        }

        // POST: Infos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var info = await _context.Info
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.InfoIndex == id);
            if (info == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Info.Remove(info);
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
