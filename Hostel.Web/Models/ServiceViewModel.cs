using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Web.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string NameService { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
    }
}
