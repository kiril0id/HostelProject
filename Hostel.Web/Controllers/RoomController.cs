using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hostel.BusinessLogic.Services;

namespace Hostel.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoom _room;

        public RoomController(IRoom room)
        {
            _room = room;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListFreeRoom(string leftDate, string rightDate)
        {
            //var left= Convert.ToDateTime(leftDate); 
            //var right= Convert.ToDateTime(rightDate);
            //ViewBag.left = left.ToShortDateString();.
            //ViewBag.right = right.ToShortDateString();
            //return View("ListFreeRoom", _room.GetAllFreeRooms(left, right));

            var left = Convert.ToDateTime(leftDate);
            var right = Convert.ToDateTime(rightDate);
            ViewBag.left = left.ToShortDateString();
            ViewBag.right = right.ToShortDateString();
            return View("ListFreeRoom", _room.GetAllFreeRooms(left, right));
        }
        [HttpGet]
        public IActionResult RoomDetails(int id)
        {
            return View("RoomDetails",_room.GetRomm(id));
        }
        [HttpGet]
        public IActionResult AllRoom()
        {
            return View("AllRoom", _room.GetAllRooms());
        }
    }
}
