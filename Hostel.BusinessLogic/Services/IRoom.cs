using System;
using System.Collections.Generic;
using System.Text;
using Hostel.BusinessLogic.Models;
using Hostel.Data.Models;
namespace Hostel.BusinessLogic.Services
{
    public interface IRoom
    {
        IEnumerable<Room> GetAllFreeRooms(RoomFreeBl room);

        IEnumerable<Room> GetAllFreeRooms(DateTime left, DateTime right);
        IEnumerable<Room> GetAllRooms();
        IEnumerable<RoomBl> GetAllFreeRoomsWithProp(RoomFreeBl room);
        RoomBl GetRoom(int id);
        IEnumerable<string> Types();
        IEnumerable<RoomBl> GetAllRoomsWithProp();

    }
}
