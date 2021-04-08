using System;
using System.Collections.Generic;
using System.Text;

namespace Hostel.BusinessLogic.Models
{
  public  class RoomBl
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public decimal? Cost { get; set; }
        public int? Сapacity { get; set; }
        public string Type { get; set; }

        public bool? Shower { get; set; }
        public bool? Restroom { get; set; }
        public string Description { get; set; }
        public int? Bed { get; set; }
        public bool? Wifi { get; set; }
        public bool? Tv { get; set; }
        public bool? Fridge { get; set; }
    }
}
