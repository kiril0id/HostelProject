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
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private const string cookieDateLeft = "DateLeft";
        private const string cookieDateRight = "DateRight";
        private const string cookieIdRoom = "IdRoom";
        private const string cookieClient = "Client";
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

        #region Service 
        public IActionResult ListService()
        {
            return View("Service/Services", _admin.GetService());
        }


        public IActionResult Service(int id)
        {
            return View("Service/Service", _mapper.Map<ServiceViewModel>(_admin.GetService(id)));
        }
        [HttpGet]
        public IActionResult CreateService()
        {
            return View("Service/ServiceCreate");
        }
        [HttpPost]
        public IActionResult CreateService(ServiceViewModel service)
        {
            _admin.CreateService(_mapper.Map<ServiceBl>(service));
            return RedirectToAction("ListService");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
            return View("Service/ServiceEdit", _mapper.Map<ServiceViewModel>(_admin.GetService(id)));
        }
        [HttpPost]
        public IActionResult EditService(ServiceViewModel service)
        {
            _admin.EditService(_mapper.Map<ServiceBl>(service));
            return RedirectToAction("ListService");
        }
        public IActionResult DeleteService(int id)
        {
            _admin.DeleteService(id);
            return RedirectToAction("ListService");
        }


        #endregion

        #region Booking
        [HttpGet]
        public IActionResult SelectDate()
        {
            return View("CreateHandling/SelectDate");
        }
        [HttpPost]
        public IActionResult SelectDate(DateViewModel date)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(20);
            Response.Cookies.Append(cookieDateLeft, date.Left.ToString(), options);
            Response.Cookies.Append(cookieDateRight, date.Right.ToString(), options);

            return RedirectToAction("SelectRoom", "Admin");
        }
        [HttpGet]
        public IActionResult SelectRoom()
        {
            DateTime left = Convert.ToDateTime(Request.Cookies[cookieDateLeft]);
            DateTime right = Convert.ToDateTime(Request.Cookies[cookieDateRight]);
            ViewBag.left = left;
            ViewBag.right = right;
            return View("CreateHandling/SelectRoom", _room.GetAllFreeRooms(_mapper.Map<RoomFreeBl>(new SearchRoomData { InCheck = left, OutCheck = right })));
        }
        public IActionResult SelectRoomEnd(int id)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(20);
            Response.Cookies.Append(cookieIdRoom, id.ToString(), options);
            return RedirectToAction("SelectClient", "Admin");
        }
        [HttpGet]
        public IActionResult SelectClient()
        {
            DateTime left = Convert.ToDateTime(Request.Cookies[cookieDateLeft]);
            DateTime right = Convert.ToDateTime(Request.Cookies[cookieDateRight]);
            int idRoom = Convert.ToInt32(Request.Cookies[cookieIdRoom]);
            ViewBag.left = left;
            ViewBag.right = right;
            ViewBag.idRoom = idRoom;
            return View("CreateHandling/SelectClient", _admin.GetClient());
        }
        [HttpGet]
        public IActionResult CreateClientForBooking()
        {
            return View("CreateHandling/CreateClientBooking");
        }
        [HttpPost]
        public IActionResult CreateClientForBooking(ClientViewModel client)
        {
            client.idRole = (int)RoleType.user;
            var id = _admin.CreateClient(_mapper.Map<ClientBl>(client));
            if (id != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(20);
                Response.Cookies.Append(cookieClient, id.ToString(), options);
                return RedirectToAction("RegistrationBooking");
            }
            else
            {
                //isfalid
                return RedirectToAction("CreateClientForBooking");
            }
        }

        public IActionResult SelectClientEnd(int id)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(20);
            Response.Cookies.Append(cookieClient, id.ToString(), options);
            return RedirectToAction("RegistrationBooking", "Admin");
        }
        [HttpGet]
        public IActionResult RegistrationBooking()
        {

            BookingViewModel bookingView = _mapper.Map<BookingViewModel>(_admin.GetBooking(Convert.ToInt32(Request.Cookies[cookieClient]), Convert.ToInt32(Request.Cookies[cookieIdRoom])));
            bookingView.handling.InCheck = Convert.ToDateTime(Request.Cookies[cookieDateLeft]);
            bookingView.handling.OutCheck = Convert.ToDateTime(Request.Cookies[cookieDateRight]);


            return View("CreateHandling/RegistrationBooking", bookingView);
        }


        public IActionResult RegistrationBookingEnd()
        {

            HandlingViewModel handling = new HandlingViewModel
            {
                IdClient = Convert.ToInt32(Request.Cookies[cookieClient]),
                InCheck = Convert.ToDateTime(Request.Cookies[cookieDateLeft]),
                OutCheck = Convert.ToDateTime(Request.Cookies[cookieDateRight]),
                IdRoom = Convert.ToInt32(Request.Cookies[cookieIdRoom]),
                IdEmployee = 3,


            };

            if (_admin.CreateHandling(_mapper.Map<HandlingBl>(handling)))
            {
                Response.Cookies.Delete(cookieDateLeft);
                Response.Cookies.Delete(cookieDateRight);
                Response.Cookies.Delete(cookieIdRoom);
                Response.Cookies.Delete(cookieClient);

                return RedirectToAction("ListHandling", "Admin");
            }
            else
            {
                return Content("Error");
            }
        }






        #endregion






    }
}
