using System;
using System.Collections.Generic;
using System.Text;

namespace Hostel.BusinessLogic.Models
{
    public class BookingBl
    {
        public HandlingBl handling { get; set; }
        public ClientBl client { get; set; }
        public RoomBl room { get; set; }
    }
}
