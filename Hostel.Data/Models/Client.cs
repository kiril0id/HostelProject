using System;
using System.Collections.Generic;

namespace Hostel.Data.Models
{
    public partial class Client
    {
        public Client()
        {
            Handling = new HashSet<Handling>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Passport { get; set; }
        public DateTime? DatofBirth { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }

        public virtual ClientWeb ClientWeb { get; set; }
        public virtual ICollection<Handling> Handling { get; set; }
    }
}
