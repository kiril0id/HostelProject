using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hostel.Web.Models;
using Hostel.BusinessLogic.Services;
using Hostel.Data.Models;

namespace Hostel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoom _room;

        public HomeController(IRoom room)
        {
            _room = room;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string leftDate, string rightDate)
        {
            var left = Convert.ToDateTime(leftDate);
            var right = Convert.ToDateTime(rightDate);
            return View("Privacy", _room.GetAllFreeRooms(left, right));
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
