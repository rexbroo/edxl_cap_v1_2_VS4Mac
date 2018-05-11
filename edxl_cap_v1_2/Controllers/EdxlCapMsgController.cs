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
    public class EdxlCapMsgController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EdxlCapMsgController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EdxlCapMessages
        public async Task<IActionResult> Index()
        {
            List<EdxlCapMsg> identifierlist = new List<EdxlCapMsg>();

            //------Getting Data fom Database using EntityFrameworkCore------
            identifierlist = (from product in _context.EdxlCapMsg
                              select product).ToList();

            //------Inserting Select Item in List------
            identifierlist.Insert(0, new EdxlCapMsg { Id = 0, Alert_Identifier = "Select" });

            //------Assigning countrylist to ViewBag.ListofCountry------
            ViewBag.ListofIdentifier = identifierlist;


            return View(await _context.EdxlCapMsg.ToListAsync());
        }

        [HttpPost]

        public IActionResult Index(EdxlCapMsg EdxlCapMsg)
        {
            //------Validation------
            if (EdxlCapMsg.Id == 0)
            {
                ModelState.AddModelError("", "Select EdxlCapMsg");
            }

            //------Getting selected value------
            int SelectedValue = EdxlCapMsg.Id;

            ViewBag.SelectedValue = EdxlCapMsg.Id;

            //------Setting Data back to ViewBag after Posting form------
            List<EdxlCapMsg> identifierlist = new List<Models.EdxlCapMsg>();

            identifierlist = (from product in _context.EdxlCapMsg
                           select product).ToList();

            identifierlist.Insert(0, new EdxlCapMsg { Id = 0, Alert_Identifier = "Select" });
            ViewBag.ListofIdentifier = identifierlist;

            return View();
        }

    }

    //// GET: EdxlCapMessages/Details/5
    //public async Task<IActionResult> Details(string id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var edxlCapMsg = await _context.EdxlCapMsg
    //            .SingleOrDefaultAsync(m => m.Alert_Identifier == id);
    //        if (edxlCapMsg == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(edxlCapMsg);
    //    }

    //    // GET: EdxlCapMessages/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: EdxlCapMessageViewModels/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Alert_Identifier")] EdxlCapMsg edxlCapMsg)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(edxlCapMsg);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(edxlCapMsg);
    //    }

    //    // GET: EdxlCapMessages/Edit/5
    //    public async Task<IActionResult> Edit(string id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var edxlCapMsg = await _context.EdxlCapMsg.SingleOrDefaultAsync(m => m.Alert_Identifier == id);
    //        if (edxlCapMsg == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(edxlCapMsg);
    //    }

    //    // POST: EdxlCapMessages/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(string id, [Bind("Alert_Identifier")] EdxlCapMsg edxlCapMsg)
    //    {
    //        if (id != edxlCapMsg.Alert_Identifier)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(edxlCapMsg);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!EdxlCapMsgExists(edxlCapMsg.Alert_Identifier))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(edxlCapMsg);
    //    }

    //    // GET: EdxlCapMessages/Delete/5
    //    public async Task<IActionResult> Delete(string id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var edxlCapMsg = await _context.EdxlCapMsg
    //            .SingleOrDefaultAsync(m => m.Alert_Identifier == id);
    //        if (edxlCapMsg == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(edxlCapMsg);
    //    }

    //    // POST: EdxlCapMessages/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(string id)
    //    {
    //        var edxlCapMsg = await _context.EdxlCapMsg.SingleOrDefaultAsync(m => m.Alert_Identifier == id);
    //        _context.EdxlCapMsg.Remove(edxlCapMsg);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool EdxlCapMsgExists(string id)
    //    {
    //        return _context.EdxlCapMsg.Any(e => e.Alert_Identifier == id);
    //    }
    //}
}
