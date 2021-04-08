using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hostel.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdmin _admin;
        private readonly IRoom _room;

        public AdminController(IAdmin admin, IRoom room)
        {
            _admin = admin;
            _room = room;
        }
        public IActionResult IndexAdmin()
        {
           
            return View("IndexAdmin", _admin.GetHandling());
        }
        public IActionResult ListHandling()
        {
            return View("Handlings", _admin.GetHandling());
        }
        public IActionResult ListNowHandling ()
        {
            return View("Handlings", _admin.GetNowHandling(DateTime.Now, DateTime.Now));
        }
        public IActionResult ListRoom()
        {
            return View("Rooms", _room.GetAllRooms() ); 
        }
        public IActionResult ListClient()
        {
            return View("Clients", _admin.GetClient());
        }
        //public IActionResult Handing(int id)
        //{
        //    return View();
        //}
        //public IActionResult Room(int id)
        //{
        //    return View();
        //}



        //public IActionResult Client(int id)
        //{
        //    return View();
        //}


    }
}
