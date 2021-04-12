using System;
using System.Collections.Generic;
using System.Text;
using Hostel.Data.Models;
namespace Hostel.BusinessLogic.Services
{
    public interface IRoom
    {
        IEnumerable<Room> GetAllFreeRooms(DateTime left, DateTime right);
        IEnumerable<Room> GetAllRooms();
        Room GetRomm(int id);


    }
}
