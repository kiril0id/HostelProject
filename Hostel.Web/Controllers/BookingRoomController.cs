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
        private const string cookieType = "Type";

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
        public IActionResult DashboardRoom()
        {
            //var left= Convert.ToDateTime(leftDate); 
            //var right= Convert.ToDateTime(rightDate);
            //ViewBag.left = left.ToShortDateString();.
            //ViewBag.right = right.ToShortDateString();
            //return View("ListFreeRoom", _room.GetAllFreeRooms(left, right));
            DateTime left;
            DateTime right;
            string type;
           
            if (Request.Cookies.ContainsKey(cookieDateLeft))
            {
                 left= Convert.ToDateTime(Request.Cookies[cookieDateLeft]);
            }
            else
            {
                left = DateTime.Now;
            }
            if (Request.Cookies.ContainsKey(cookieDateRight))
            {
                right = Convert.ToDateTime(Request.Cookies[cookieDateRight]);
            }
            else
            {
                right = DateTime.Now.AddDays(1);
            }
            if (Request.Cookies.ContainsKey(cookieType))
            {
                type = Request.Cookies[cookieType];
            }
            else
            {
                type = null;
            }
            

            ViewBag.left = left.ToShortDateString();
            ViewBag.right = right.ToShortDateString();
            ViewBag.type = type;
            ViewBag.types = _room.Types();
            return View("SelectRoom", _room.GetAllFreeRoomsWithProp(_mapper.Map<RoomFreeBl>(new RoomFreeViewModel { InCheck = left, OutCheck = right, Type = type})));
        }

         [HttpPost]
        public IActionResult DashboardRoom(string left, string right, string type)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(20);
            Response.Cookies.Append(cookieDateLeft, left.ToString(), options);
            Response.Cookies.Append(cookieDateRight, right.ToString(), options);
            Response.Cookies.Append(cookieType, type.ToString(), options);


            return RedirectToAction("DashboardRoom", "BookingRoom");
        }





    }
}
