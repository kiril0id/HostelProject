using Hostel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Hostel.BusinessLogic.Models;

namespace Hostel.BusinessLogic.Services
{
    public class BookingRoom : IRoom
    {
        private readonly bdHostelContext _context;

        public BookingRoom(bdHostelContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAllFreeRooms(RoomFreeBl room)
        {
            // return _context.Room.FromSqlRaw($"select * from AllFreeRomms({left}, {right})").AsNoTracking().ToList();
            //            select* from[dbo].[Room]
            //            where id not iN(select id_room from[dbo].[Handling]
            //where (inCheck<@left AND outCheck> @right) or(inCheck<@right ))
            var sub = (from tab2 in _context.Handling
                       where ((tab2.InCheck > room.InCheck) && (tab2.OutCheck < room.OutCheck)) || ((tab2.InCheck < room.InCheck) && (tab2.OutCheck > room.InCheck)) || ((tab2.InCheck < room.OutCheck) && (tab2.OutCheck > room.OutCheck))
                       //where tab2.InCheck < left && tab2.OutCheck > right
                       select tab2.IdRoom).ToList();

            return _context.Room.Where(w => !sub.Contains(w.Id)).ToList();



        }
        public IEnumerable<Room> GetAllFreeRooms(DateTime left, DateTime right)
        {
            // return _context.Room.FromSqlRaw($"select * from AllFreeRomms({left}, {right})").AsNoTracking().ToList();
            //            select* from[dbo].[Room]
            //            where id not iN(select id_room from[dbo].[Handling]
            //where (inCheck<@left AND outCheck> @right) or(inCheck<@right ))
            var sub = (from tab2 in _context.Handling
                       where ((tab2.InCheck > left) && (tab2.OutCheck < right)) || ((tab2.InCheck < left) && (tab2.OutCheck > left)) || ((tab2.InCheck < right) && (tab2.OutCheck > right))
                       //where tab2.InCheck < left && tab2.OutCheck > right
                       select tab2.IdRoom).ToList();

            return _context.Room.Where(w => !sub.Contains(w.Id)).AsNoTracking().ToList();



        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Room.ToList();
        }
        public IEnumerable<RoomBl> GetAllRoomsWithProp()
        {
            List<RoomBl> listRoomBl = new List<RoomBl>();

            List<Room> room = _context.Room.ToList();
            List<RoomProp> roomProp = _context.RoomProp.ToList();
            RoomBl roomBl;
            for (int i = 0; i < room.Count; i++)
            {
                if (roomProp[i] == null)
                {
                    roomBl = new RoomBl
                    {
                        Id = room[i].Id,
                        Number = room[i].Number,
                        Cost = (int)room[i].Cost,
                        Сapacity = room[i].Сapacity,
                        Type = room[i].Type,

                        Shower = false,
                        Restroom = false,
                        Description = "",
                        Bed = 0,
                        Wifi = false,
                        Tv = false,
                        Fridge = false,
                    };
                }
                else
                {
                    roomBl = new RoomBl
                    {
                        Id = room[i].Id,
                        Number = room[i].Number,
                        Cost = (int)room[i].Cost,
                        Сapacity = room[i].Сapacity,
                        Type = room[i].Type,

                        Shower = roomProp[i].Shower == null ? false : roomProp[i].Shower,
                        Restroom = roomProp[i].Restroom == null ? false : roomProp[i].Restroom,
                        Description = roomProp[i].Description == null ? "" : roomProp[i].Description,
                        Bed = roomProp[i].Bed == null ? 0 : roomProp[i].Bed,
                        Wifi = roomProp[i].Wifi == null ? false : roomProp[i].Wifi,
                        Tv = roomProp[i].Tv == null ? false : roomProp[i].Tv,
                        Fridge = roomProp[i].Fridge == null ? false : roomProp[i].Fridge,
                    };
                }
                listRoomBl.Add(roomBl);
            }

            return listRoomBl;
        }

        public IEnumerable<RoomBl> GetAllFreeRoomsWithProp(RoomFreeBl room)
        {
            var sub = (from tab2 in _context.Handling
                       where ((tab2.InCheck > room.InCheck) && (tab2.OutCheck < room.OutCheck)) || ((tab2.InCheck < room.InCheck) && (tab2.OutCheck > room.InCheck)) || ((tab2.InCheck < room.OutCheck) && (tab2.OutCheck > room.OutCheck))
                       //where tab2.InCheck < left && tab2.OutCheck > right
                       select tab2.IdRoom).ToList();



            var allRooms = (List<RoomBl>)GetAllRoomsWithProp();
            return allRooms.Where(w => !sub.Contains(w.Id) && w.Type == room.Type).ToList();
        }

        public RoomBl GetRoom(int id)
        {
            Room room = _context.Room.FirstOrDefault(p => p.Id == id);
            RoomProp roomProp = _context.RoomProp.FirstOrDefault(p => p.IdRoom == id);
            RoomBl roomBl;
            if (roomProp == null)
            {
                roomBl = new RoomBl
                {
                    Id = room.Id,
                    Number = room.Number,
                    Cost = (int)room.Cost,
                    Сapacity = room.Сapacity,
                    Type = room.Type,

                    Shower = false,
                    Restroom = false,
                    Description = "",
                    Bed = 0,
                    Wifi = false,
                    Tv = false,
                    Fridge = false,
                };
            }
            else
            {
                roomBl = new RoomBl
                {
                    Id = room.Id,
                    Number = room.Number,
                    Cost = (int)room.Cost,
                    Сapacity = room.Сapacity,
                    Type = room.Type,

                    Shower = roomProp.Shower == null ? false : roomProp.Shower,
                    Restroom = roomProp.Restroom == null ? false : roomProp.Restroom,
                    Description = roomProp.Description == null ? "" : roomProp.Description,
                    Bed = roomProp.Bed == null ? 0 : roomProp.Bed,
                    Wifi = roomProp.Wifi == null ? false : roomProp.Wifi,
                    Tv = roomProp.Tv == null ? false : roomProp.Tv,
                    Fridge = roomProp.Fridge == null ? false : roomProp.Fridge,
                };
            }

            return roomBl;
        }

        public IEnumerable<string> Types()
        {
            return _context.Room.Select(x => x.Type).Distinct().ToList();

        }

        
    }
}
