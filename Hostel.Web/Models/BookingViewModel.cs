using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Web.Models
{
    public class BookingViewModel
    {
        public HandlingViewModel handling { get; set; }
        public ClientViewModel  client { get; set; }
        public RoomViewModel room { get; set; }

    }
}
