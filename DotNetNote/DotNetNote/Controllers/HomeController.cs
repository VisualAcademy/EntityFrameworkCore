using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetNote.Models;

namespace DotNetNote.Controllers
{
    public class HomeController : Controller
    {
        private readonly DotNetNoteContext _context;

        public HomeController(DotNetNoteContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ideas = _context.Ideas.ToList();
            return View(ideas);
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
