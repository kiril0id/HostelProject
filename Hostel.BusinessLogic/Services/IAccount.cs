using Hostel.BusinessLogic.Models;
using Hostel.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hostel.BusinessLogic.Services
{
   public  interface IAccount
   {
         ClientFullInformation Login(LoginModel model);
         bool Register(ClientFullInformation client);

    }
}
