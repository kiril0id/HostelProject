using System;
using System.Collections.Generic;
using System.Text;

namespace Hostel.BusinessLogic.Models
{
    public class HandlingBl
    {
        public int Id { get; set; }
        public int? IdClient { get; set; }
        public string LastName { get; set; }
        public DateTime? InCheck { get; set; }
        public DateTime? OutCheck { get; set; }
        public int? IdRoom { get; set; }
        public int Room { get; set; }
        public int? IdService { get; set; }
        public int? IdService2 { get; set; }
        public int? IdService3 { get; set; }
        public int? IdBooking { get; set; }
        public int? IdEmployee { get; set; }
    }
}
