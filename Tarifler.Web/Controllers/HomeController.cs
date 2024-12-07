using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tarifler.Core.Entity;
using Tarifler.Data;
using Tarifler.Web.Models;

namespace Tarifler.Web.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
            
        }

        public async Task<IActionResult> Index(string ara="")
        {
            if (ara != null)
            {
                TempData["Ara"] = ara;
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
