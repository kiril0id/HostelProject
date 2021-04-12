using System;
using System.Collections.Generic;

namespace Hostel.Data.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Handling = new HashSet<Handling>();
        }

        public int Id { get; set; }
        public int? Code { get; set; }

        public virtual ICollection<Handling> Handling { get; set; }
    }
}
