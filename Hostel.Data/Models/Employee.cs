using System;
using System.Collections.Generic;

namespace Hostel.Data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Handling = new HashSet<Handling>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public DateTime? DatofBirth { get; set; }
        public string Telephone { get; set; }
        public string Passport { get; set; }
        public int? IdPosition { get; set; }

        public virtual Position IdPositionNavigation { get; set; }
        public virtual ICollection<Handling> Handling { get; set; }
    }
}
