using System;
using System.Collections.Generic;

namespace Hostel.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            ClientWeb = new HashSet<ClientWeb>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ClientWeb> ClientWeb { get; set; }
    }
}
