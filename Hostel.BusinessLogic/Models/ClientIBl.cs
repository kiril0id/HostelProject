using System;
using System.Collections.Generic;
using System.Text;

namespace Hostel.BusinessLogic.Models
{
   public  class ClientBl
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Passport { get; set; }
        public DateTime? DatofBirth { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public int idRole { get; set; }
    
    }
}
