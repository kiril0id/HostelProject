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
        IEnumerable<Handling> GetHandling();
        bool CreateNewHandling(Handling handling);
        bool DeleteHandling(int id);
        bool EditHandling(Handling handling);
        //Client 
        IEnumerable<Client> GetClient();
        ClientBl GetClient(int id);
        bool CreateNewClient(Client client);
        bool EditClient(Client clietn);
        bool DeleteClient(int id);

        //Room
        
        bool CreateRoom(RoomBl room);
        bool EditRoom(RoomBl room);
        bool DeleteRomm(int id);
        //Employee
        

    }
}
