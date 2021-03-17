using System;
using System.Collections.Generic;

namespace Hostel.Data.Models
{
    public partial class Handling
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public DateTime InCheck { get; set; }
        public DateTime OutCheck { get; set; }
        public int IdRoom { get; set; }
        public int? IdService { get; set; }
        public int? IdService2 { get; set; }
        public int? IdService3 { get; set; }
        public int? IdBooking { get; set; }
        public int IdEmployee { get; set; }

        public virtual Booking IdBookingNavigation { get; set; }
        public virtual Client IdClientNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Room IdRoomNavigation { get; set; }
        public virtual Service IdService2Navigation { get; set; }
        public virtual Service IdService3Navigation { get; set; }
        public virtual Service IdServiceNavigation { get; set; }
    }
}
