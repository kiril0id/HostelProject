using System;
using System.Collections.Generic;

namespace Hostel.Data.Models
{
    public partial class Position
    {
        public Position()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
