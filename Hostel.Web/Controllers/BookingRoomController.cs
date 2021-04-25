using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hostel.BusinessLogic.Models;
using Hostel.BusinessLogic.Services;
using Hostel.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.Web.Controllers
{
    //[Authorize(Roles = "admin, user")]
   
    public class BookingRoomController : Controller
    {
        private readonly IRoom _room;
        private readonly IMapper _mapper;
        private const string cookieDateLeft = "DateLeft";
        private const string cookieDateRight = "DateRight";
        private const string cookieIdRoom = "IdRoom";
        private const string cookieClient = "Client";

        public BookingRoomController(IRoom room, IMapper mapper)
        {
            _room = room;
            _mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult DashboardRoom(string left, string right, string type)
        //{
        //    var leftDate = Convert.ToDateTime(left);
        //    var rightDate = Convert.ToDateTime(right);
        //    ViewBag.left = leftDate.ToShortDateString();
        //    ViewBag.right = rightDate.ToShortDateString();

        //    //TODO: add cooke
           
        //    //
        //    return View("SelectRoom", _room.GetAllFreeRoomsWithProp(leftDate, rightDate));
        //}

        [HttpGet]
        public IActionResult DashboardRoom(RoomFreeViewModel room)
        {
            //var left= Convert.ToDateTime(leftDate); 
            //var right= Convert.ToDateTime(rightDate);
            //ViewBag.left = left.ToShortDateString();.
            //ViewBag.right = right.ToShortDateString();
            //return View("ListFreeRoom", _room.GetAllFreeRooms(left, right));

            //TODO: add cooke
            var left = room.InCheck;
            var right = room.OutCheck;

            ViewBag.left = left.ToShortDateString();
            ViewBag.right = right.ToShortDateString();
            //
            return View("SelectRoom", _room.GetAllFreeRoomsWithProp(_mapper.Map<RoomFreeBl>(room)));
        }

        //[HttpPost]
        //public IActionResult DashboardRoom()
        //{
        //    return View();
        //}





    }
}
