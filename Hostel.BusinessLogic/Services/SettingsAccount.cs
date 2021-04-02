using Hostel.BusinessLogic.Models;
using Hostel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hostel.BusinessLogic.Services
{
    public class SettingsAccount : IAccount
    {
        private readonly bdHostelContext _context;

        public SettingsAccount(bdHostelContext context)
        {
            _context = context;
        }

        public ClientFullInformation Login(LoginModel model)
        {
            var clientFull = new ClientFullInformation();

            ClientWeb clientWeb = _context.ClientWeb.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            Client client = _context.Client.FirstOrDefault(u => u.Id == clientWeb.IdClient);
            clientFull.Id  =client.Id;
            clientFull.FirstName = client.FirstName;
            clientFull.LastName = client.LastName;
            clientFull.Surname = client.Surname;
            clientFull.Passport = client.Passport;
            clientFull.DatofBirth = client.DatofBirth;
            clientFull.Adress = client.Adress;
            clientFull.Telephone = client.Telephone;
            clientFull.Email = clientWeb.Email;
            clientFull.Password = clientWeb.Password;
            clientFull.idRole = (int)clientWeb.IdRole;

            return clientFull;
        }

        public bool Register(ClientFullInformation client)
        {
            try
            {
               
                var dboClient = new Client
                {
                    FirstName = "nice"
                };
                _context.Client.Add(dboClient);
                _context.SaveChanges();
                var c = new ClientWeb
                {
                    IdClient = dboClient.Id,
                    Email = client.Email,
                    Password = client.Password,
                    IdRole = client.idRole
                };
                _context.ClientWeb.Add(c);
                    _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                string x = ex.Message;
                return false;
            }
        }
    }
}
