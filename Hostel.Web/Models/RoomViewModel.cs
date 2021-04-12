using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Web.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Cost { get; set; }
        public int Сapacity { get; set; }
        public string Type { get; set; }

        public bool Shower { get; set; }
        public bool Restroom { get; set; }
        public string Description { get; set; }
        public int Bed { get; set; }
        public bool Wifi { get; set; }
        public bool Tv { get; set; }
        public bool Fridge { get; set; }
    }
}
