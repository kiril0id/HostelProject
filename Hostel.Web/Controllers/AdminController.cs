using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hostel.BusinessLogic.Models;
using Hostel.BusinessLogic.Services;
using Hostel.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdmin _admin;
        private readonly IRoom _room;
        private readonly IMapper _mapper;
        public AdminController(IAdmin admin, IRoom room, IMapper mapper)
        {
            _admin = admin;
            _room = room;
            _mapper = mapper;
        }
        #region Client
        public IActionResult ListClient()
        {
            return View("Client/Clients", _admin.GetClient());
        }

        [HttpGet]
        public IActionResult CreateClient()
        {
            return View("Client/ClientCreate");
        }
        [HttpPost]
        public IActionResult CreateClient(ClientViewModel client)
        {
            _admin.CreateClient(_mapper.Map<ClientBl>(client));
            return RedirectToAction("ListClient");
        }
        [HttpGet]
        public IActionResult EditClinet(int id)
        {
            return View("Client/ClientEdit", _mapper.Map<ClientViewModel>(_admin.GetClient(id)));
        }
        [HttpPost]
        public IActionResult EditClient(ClientViewModel client)
        {
            _admin.EditClient(_mapper.Map<ClientBl>(client));
            return RedirectToAction("ListClient");
        }
        public IActionResult DeleteClient(int id)
        {
            _admin.DeleteClient(id);
            return RedirectToAction("ListClient");
        }
        public IActionResult Client(int id)
        {
            return View("Client/Client", _mapper.Map<ClientViewModel>(_admin.GetClient(id)));
        }

        #endregion

        #region Room
        public IActionResult ListRoom()
        {
            return View("Room/Rooms", _room.GetAllRooms());
        }
        [HttpGet]
        public IActionResult CreateRoom()
        {
            return View("Room/RoomCreate");
        }
        [HttpPost]
        public IActionResult CreateRoom(RoomViewModel room)
        {
            _admin.CreateRoom(_mapper.Map<RoomBl>(room));
            return RedirectToAction("ListRoom");
        }


        [HttpGet]
        public IActionResult EditRoom(int id)
        {
            return View("Room/RoomEdit", _mapper.Map<RoomViewModel>(_admin.GetRoom(id)));
        }
        [HttpPost]
        public IActionResult EditRoom(RoomViewModel room)
        {
            _admin.EditRoom(_mapper.Map<RoomBl>(room));
            return RedirectToAction("ListRoom");
        }
        public IActionResult DeleteRoom(int id)
        {
            _admin.DeleteRoom(id);
            return RedirectToAction("ListRoom");
        }
        public IActionResult Room(int id)
        {
            return View("Room/Room", _mapper.Map<RoomViewModel>(_admin.GetRoom(id)));
        }

        #endregion


        public IActionResult IndexAdmin()
        {
            return View("IndexAdmin");
        }
        #region Handling
        public IActionResult ListHandling()
        {
            return View("Handling/Handlings", _admin.GetHandling());
        }
        public IActionResult ListNowHandling()
        {
            return View("Handling/Handlings", _admin.GetNowHandling(DateTime.Now, DateTime.Now));
        }


        public IActionResult Handling(int id)
        {
            return View("Handling/Handling", _mapper.Map<HandlingViewModel>(_admin.Handling(id)));
        }
        [HttpGet]
        public IActionResult CreateHandling()
        {
            return View("Handling/HandlingCreate");
        }
        [HttpPost]
        public IActionResult CreateHandling(HandlingViewModel handling)
        {
            _admin.CreateHandling(_mapper.Map<HandlingBl>(handling));
            return RedirectToAction("ListHandling");
        }
        [HttpGet]
        public IActionResult EditHandling(int id)
        {
            return View("Handling/HandlingEdit", _mapper.Map<HandlingViewModel>(_admin.Handling(id)));
        }
        [HttpPost]
        public IActionResult EditHandling(HandlingViewModel handling)
        {
            _admin.EditHandling(_mapper.Map<HandlingBl>(handling));
            return RedirectToAction("ListHandling");
        }
        public IActionResult DeleteHandling(int id)
        {
            _admin.DeleteHandling(id);
            return RedirectToAction("ListHandling");
        }
        #endregion







    }
}
