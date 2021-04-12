using Hostel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
namespace Hostel.BusinessLogic.Services
{
    public class BookingRoom : IRoom
    {
        private readonly bdHostelContext _context;

        public BookingRoom(bdHostelContext context)
        {
            _context = context;
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

        public Room GetRomm(int id)
        {
            return _context.Room.Find(id);
        }
    }
}
