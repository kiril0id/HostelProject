using System;
using System.Collections.Generic;

namespace Hostel.Data.Models
{
    public partial class ClientWeb
    {
        public int IdClient { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IdRole { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
