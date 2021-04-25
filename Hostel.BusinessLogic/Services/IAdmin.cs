using Hostel.BusinessLogic.Models;
using Hostel.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hostel.BusinessLogic.Services
{
    public interface IAdmin
    {
        //Handling
        IEnumerable<HandlingBl> GetHandling();
        bool CreateHandling(HandlingBl handling);
        bool DeleteHandling(int id);
        bool EditHandling(HandlingBl handling);
        IEnumerable<HandlingBl> GetNowHandling(DateTime left, DateTime right);
        HandlingBl Handling(int id);
        //Client 
        IEnumerable<Client> GetClient();
        ClientBl GetClient(int id);
        int? CreateClient(ClientBl client);
        bool EditClient(ClientBl client);
        bool DeleteClient(int id);

        //Room
        RoomBl GetRoom(int id);
        bool CreateRoom(RoomBl room);
        bool EditRoom(RoomBl room);
        bool DeleteRoom(int id);
        //Employee

        //Service
        IEnumerable<ServiceBl> GetService();
        ServiceBl GetService(int id);
        bool CreateService(ServiceBl client);
        bool EditService(ServiceBl client);
        bool DeleteService(int id);

        //booking

        BookingBl GetBooking(int IdClient, int IdRoom);

    }
}
