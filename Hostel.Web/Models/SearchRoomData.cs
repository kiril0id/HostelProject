using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Web.Models
{
    public class SearchRoomData
    {
        public DateTime InCheck { get; set; }
        public DateTime OutCheck { get; set; }
        public string Type { get; set; }
    }
}
