using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hostel.BusinessLogic.Services;
using Hostel.Web.Models;
using AutoMapper;
using Hostel.BusinessLogic.Models;

namespace Hostel.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoom _room;
        private readonly IMapper _mapper;

        public RoomController(IRoom room, IMapper mapper)
        {
            _room = room;
            _mapper = mapper;
        }

        public IActionResult ListFreeRoom(SearchRoomData room)
        {
            //var left= Convert.ToDateTime(leftDate); 
            //var right= Convert.ToDateTime(rightDate);
            //ViewBag.left = left.ToShortDateString();.
            //ViewBag.right = right.ToShortDateString();
            //return View("ListFreeRoom", _room.GetAllFreeRooms(left, right));

            //TODO add cooke
            var left = room.InCheck;
            var right = room.OutCheck;

            ViewBag.left = left.ToShortDateString();
            ViewBag.right = right.ToShortDateString();
            //
            return View("ListFreeRoom", _room.GetAllFreeRooms(_mapper.Map<RoomFreeBl>(room)));
        }
        [HttpGet]
        public IActionResult RoomDetails(int id)
        {
            return View("RoomDetails", _mapper.Map<RoomViewModel>(_room.GetRoom(id)));
        }
        [HttpGet]
        public IActionResult AllRoom()
        {
            return View("AllRoom", _room.GetAllRoomsWithProp());
        }
    }
}
