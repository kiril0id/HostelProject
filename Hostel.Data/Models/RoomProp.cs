using System;
using System.Collections.Generic;

namespace Hostel.Data.Models
{
    public partial class RoomProp
    {
        public int IdRoom { get; set; }
        public bool? Shower { get; set; }
        public bool? Restroom { get; set; }
        public string Description { get; set; }
        public int? Bed { get; set; }
        public bool? Wifi { get; set; }
        public bool? Tv { get; set; }
        public bool? Fridge { get; set; }

        public virtual Room IdRoomNavigation { get; set; }
    }
}
