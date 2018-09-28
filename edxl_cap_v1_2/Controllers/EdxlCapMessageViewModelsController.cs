using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using edxl_cap_v1_2.Data;
using edxl_cap_v1_2.Models;
using edxl_cap_v1_2.Models.ContentViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace edxl_cap_v1_2.Controllers
{
    public class EdxlCapMessageViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EdxlCapMessageViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Assemble()
        {
            return View();
        }

        public IActionResult _Assemble()
        {
            return View(new EdxlCapMessageViewModel());
        }

        public ActionResult _AlertPick()
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

        public ActionResult _InfoPick()
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
                Alert_Identifier = a.Alert_Identifier
            }).ToList();
            return View(vm);
        }

        public ActionResult _AreaPick()
        {
            var vm = new AreaViewModel();

            //Load the Identifiers property which will be used to build the SELECT element
            vm.Alert_Identifiers = _context.EdxlCapMsg
                                    .Select(x => new SelectListItem
                                    {
                                        Value = x.AreaIndex.ToString(),
                                        Text = x.Alert_Identifier
                                    }).ToList();

            //Load the Areas
            vm.Areas = _context.EdxlCapMsg.Select(a => new AreaVm
            {
                AreaIndex = a.AreaIndex,
                Alert_Identifier = a.Alert_Identifier
            }).ToList();
            return View(vm);
        }

        public ActionResult _ResourcePick()
        {
            var vm = new ResourceViewModel();

            //Load the Identifiers property which will be used to build the SELECT element
            vm.Alert_Identifiers = _context.EdxlCapMsg
                                    .Select(x => new SelectListItem
                                    {
                                        Value = x.ResourceIndex.ToString(),
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

        public IActionResult PickAlert(Alert obj, int? SelectedAlertIndex)
        {
            if (SelectedAlertIndex.HasValue)
            {
                ViewBag.Message = "Alert loaded successfully";
            }
            return View(_context.Alert.Where(x => x.AlertIndex == SelectedAlertIndex));
        }

        public IActionResult PickAlert4(Alert obj, int? SelectedAlertIndex)
        {
            if (SelectedAlertIndex.HasValue)
            {
                ViewBag.Message = "Alert loaded successfully";
            }
            return View("_Assemble.cshtml", _context.Alert.Where(x => x.AlertIndex == SelectedAlertIndex));
        }
    }
}