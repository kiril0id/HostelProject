using System;
using System.Collections.Generic;

namespace Hostel.Data.Models
{
    public partial class Service
    {
        public Service()
        {
            HandlingIdService2Navigation = new HashSet<Handling>();
            HandlingIdService3Navigation = new HashSet<Handling>();
            HandlingIdServiceNavigation = new HashSet<Handling>();
        }

        public int Id { get; set; }
        public string NameService { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }

        public virtual ICollection<Handling> HandlingIdService2Navigation { get; set; }
        public virtual ICollection<Handling> HandlingIdService3Navigation { get; set; }
        public virtual ICollection<Handling> HandlingIdServiceNavigation { get; set; }
    }
}
