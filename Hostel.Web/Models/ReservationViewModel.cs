using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Web.Models
{
    public class ReservationViewModel
    {
       public SearchRoomData searchRoom { get; set; }
        public List<string> Types { get; set; }
        public ClientReservation client { get; set; }
        public List<BusinessLogic.Models.RoomBl> room { get; set; }
       
    }
}
