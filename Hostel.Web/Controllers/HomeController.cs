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
using Microsoft.AspNetCore.Http;

namespace Hostel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoom _room;

        private const string cookieDateLeft = "DateLeft";
        private const string cookieDateRight = "DateRight";
        private const string cookieType = "Type";

        public HomeController(IRoom room)
        {
            _room = room;
        }
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.TypeRoom = _room.Types();
            return View(new ReservationViewModel { searchRoom  = new SearchRoomData { InCheck = DateTime.Now, OutCheck = DateTime.Now.AddDays(1)} });
        }
        [HttpPost]
        public IActionResult Index(string left, string right, string type)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(20);
            Response.Cookies.Append(cookieDateLeft, left.ToString(), options);
            Response.Cookies.Append(cookieDateRight, right.ToString(), options);
            Response.Cookies.Append(cookieType, type.ToString(), options);

            
            return RedirectToAction("DashboardRoom", "BookingRoom");
        }
        //[HttpPost]
        //public IActionResult Index(string leftDate, string rightDate)
        //{
        //    var left = Convert.ToDateTime(leftDate);
        //    var right = Convert.ToDateTime(rightDate);
        //    return View(@"~\Views\Room\ListFreeRoom.cshtml", _room.GetAllFreeRooms(left, right));
        //}

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
