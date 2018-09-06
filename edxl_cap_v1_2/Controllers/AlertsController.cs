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
    public class AlertsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlertsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alerts
        public ActionResult AlertSelect()
        {
            var vm = new AlertViewModel();

            //Load the Identifiers property which will be used to build the SELECT element
            vm.Alert_Identifiers = _context.EdxlCapMsg
                                    .Select(x => new SelectListItem
                                    {
                                        Value = x.AlertIndex.ToString(),
                                        Text = x.Alert_Identifier
                                    }).ToList();

            //Load the Alerts
            vm.Alerts = _context.EdxlCapMsg.Select(a => new AlertVm
            {
                AlertIndex = a.AlertIndex,
                Alert_Identifier = a.Alert_Identifier
            }).ToList();
            return View(vm);
        }

        //// GET: Alerts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alert.ToListAsync());
        }

        // GET: Alerts
        //public ActionResult Index(int SelectedAlertIndex)
        //{
        //    return View(_context.Alert.Where(x => x.AlertIndex == SelectedAlertIndex));
        //}

        [HttpPost]
        public IActionResult Index(Alert obj, int? SelectedAlertIndex)
        {
            if (SelectedAlertIndex.HasValue)
            {
                ViewBag.Message = "Alert loaded successfully";
            }
            return View(_context.Alert.Where(x => x.AlertIndex == SelectedAlertIndex));
        }



        // GET: Alerts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert
                //.Include(e => e.Elements)
                //    .ThenInclude(d=> d.DataCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.AlertIndex == id);

            //if (id != null)
            //{
            //    ViewData["ElementID"] = id.Value;
            //    Element element = viewModel.Element.Where(
            //        i => i.ID == id.Value).Single();
            //    viewModel.DataCategory = element.DataCategory.Select(s => s.Course);
            //}

            if (alert == null)
            {
                return NotFound();
            }

            return View(alert);
        }

        // GET: Alerts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alerts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Alert_Identifier,Sender,Sent,Status,MsgType,Source,Scope,Restriction,Addresses,Code,Note,References,Incidents,Language,DataCategory_Id")] Alert alert)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(alert);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(alert);
        }

        // GET: Alerts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert.SingleOrDefaultAsync(m => m.AlertIndex == id);
            if (alert == null)
            {
                return NotFound();
            }
            return View(alert);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var alertToUpdate = await _context.Alert.SingleOrDefaultAsync(s => s.AlertIndex == id);
            if (await TryUpdateModelAsync<Alert>(
                alertToUpdate,
                "",
                a => a.AlertIndex, a => a.Alert_Identifier, a => a.Sender, a => a.Sent, a => a.Status, a => a.MsgType, a => a.Source, a => a.Scope, a => a.Addresses, a => a.Code, a => a.Note, a => a.References, a => a.Incidents, a => a.DataCategory_Id))
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
            return View(alertToUpdate);
        }

        // GET: Alerts/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.AlertIndex == id);
            if (alert == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(alert);
        }

        // POST: Alerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alert = await _context.Alert
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.AlertIndex == id);
            if (alert == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Alert.Remove(alert);
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
