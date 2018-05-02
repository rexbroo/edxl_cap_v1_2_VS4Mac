using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using edxl_cap_v1_2.Models;

namespace edxl_cap_v1_2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexDe1()
        {
            return View();
        }

        public IActionResult IndexDe2()
        {
            return View();
        }

        public IActionResult IndexCapIntro()
        {
            return View();
        }

        public IActionResult IndexHave()
        {
            return View();
        }

        public IActionResult IndexRm()
        {
            return View();
        }

        public IActionResult IndexSitRep()
        {
            return View();
        }

        public IActionResult IndexTep()
        {
            return View();
        }

        public IActionResult IndexTec()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}