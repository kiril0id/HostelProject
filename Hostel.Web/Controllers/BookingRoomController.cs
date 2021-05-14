using AutoMapper;
using Hostel.BusinessLogic.Models;
using Hostel.BusinessLogic.Services;
using Hostel.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hostel.Web.Controllers
{
    //[Authorize(Roles = "admin, user")]

    public class BookingRoomController : Controller
    {
        private readonly IRoom _room;
        private readonly IMapper _mapper;
        private readonly IAdmin _admin;
        private const string cookieDateLeft = "DateLeft";
        private const string cookieDateRight = "DateRight";
        private const string cookieType = "Type";
        private const string cookieIdRoom = "IdRoom";

        public BookingRoomController(IRoom room, IMapper mapper, IAdmin admin)
        {
            _room = room;
            _mapper = mapper;
            _admin = admin;
        }

        [HttpGet]
        public IActionResult DashboardRoom()
        {
            DateTime left;
            DateTime right;
            string type;

            if (Request.Cookies.ContainsKey(cookieDateLeft))
            {
                left = Convert.ToDateTime(Request.Cookies[cookieDateLeft]);
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

            ViewBag.types = _room.Types();
            ReservationViewModel reservationViewModel = new ReservationViewModel
            {
                searchRoom = new SearchRoomData
                {
                    InCheck = left,
                    OutCheck = right,
                    Type = type,
                },

                room = (List<RoomBl>)_room.GetAllFreeRoomsWithProp(_mapper.Map<RoomFreeBl>(new SearchRoomData { InCheck = left, OutCheck = right, Type = type })),
            };
            return View("SelectRoom", reservationViewModel);
        }

        [HttpPost]
        public IActionResult DashboardRoom(ReservationViewModel reservationViewModel)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(20);
            Response.Cookies.Append(cookieDateLeft, reservationViewModel.searchRoom.ToString(), options);
            Response.Cookies.Append(cookieDateRight, reservationViewModel.searchRoom.ToString(), options);
            Response.Cookies.Append(cookieType, reservationViewModel.searchRoom.ToString(), options);

            return RedirectToAction("DashboardRoom", "BookingRoom");
        }

        public IActionResult RoomSelect(int id)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(20);
            Response.Cookies.Append(cookieIdRoom, id.ToString(), options);

            return RedirectToAction("ClientInformation", "BookingRoom");
        }

        [HttpGet]
        public IActionResult ClientInformation()
        {
            ReservationViewModel reservation = new ReservationViewModel
            {
                searchRoom = new SearchRoomData
                {
                    InCheck = Convert.ToDateTime(Request.Cookies[cookieDateLeft]),
                    OutCheck = Convert.ToDateTime(Request.Cookies[cookieDateRight]),
                    Type = Request.Cookies[cookieType],
                },
            };

            return View("PersonInformation", reservation);
        }

        [HttpPost]
        public IActionResult ClientInformation(ReservationViewModel reservation)
        {
            ClientViewModel client = new ClientViewModel
            {
                FirstName = reservation.client.FirstName,
                LastName = reservation.client.LastName,
                Surname = "-",
                Passport = "-",
                DatofBirth = DateTime.Now,
                Adress = "-",
                Telephone = reservation.client.Telephone,

                Email = reservation.client.Email,
                Password = "123456789",
                idRole = 4,
            };

            HandlingViewModel handling = new HandlingViewModel
            {
                InCheck = Convert.ToDateTime(Request.Cookies[cookieDateLeft]),
                OutCheck = Convert.ToDateTime(Request.Cookies[cookieDateRight]),
                IdRoom = Convert.ToInt32(Request.Cookies[cookieIdRoom]),
                IdBooking = 1,
                IdClient = (int)_admin.CreateClient(_mapper.Map<ClientBl>(client)),
                IdEmployee = 3,
            };
            _admin.CreateHandling(_mapper.Map<HandlingBl>(handling));

            if (true)
            {
                return RedirectToAction("Confirm", "BookingRoom");
            }
            else
            {
                return View("PersonInformation", reservation);
            }
        }

        [HttpGet]
        public IActionResult Confirm()
        {
            HandlingViewModel handling = new HandlingViewModel();
            ReservationViewModel reservation = new ReservationViewModel
            {
                searchRoom = new SearchRoomData
                {
                    InCheck = Convert.ToDateTime(Request.Cookies[cookieDateLeft]),
                    OutCheck = Convert.ToDateTime(Request.Cookies[cookieDateRight]),
                    Type = Request.Cookies[cookieType],
                },
            };
            return View("ConfirmBooking", reservation);
        }
    }
}