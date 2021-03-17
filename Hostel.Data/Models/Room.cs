using System;
using System.Collections.Generic;

namespace Hostel.Data.Models
{
    public partial class Room
    {
        public Room()
        {
            Handling = new HashSet<Handling>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Cost { get; set; }
        public int Сapacity { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Handling> Handling { get; set; }
    }
}
