using Hostel.BusinessLogic.Models;
using Hostel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hostel.BusinessLogic.Services
{
    public class Admin : IAdmin
    {
        private readonly bdHostelContext _context;

        public Admin(bdHostelContext context)
        {
            _context = context;
        }
        public bool CreateNewClient(Client client)
        {
            throw new NotImplementedException();

        }

        public bool CreateNewHandling(Handling handling)
        {
            try
            {
                Handling handling1 = new Handling
                {
                    Id = handling.Id,
                    IdClient = handling.IdClient,
                    InCheck = handling.InCheck,
                    OutCheck = handling.OutCheck,
                    IdRoom = handling.IdRoom,
                    IdService = handling.IdService,
                    IdService2 = handling.IdService2,
                    IdService3 = handling.IdService3,
                    IdBooking = handling.IdBooking,
                    IdEmployee = handling.IdEmployee,
                };
                _context.Handling.Add(handling1);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool CreateRoom(RoomBl room)
        {
            try
            {
                Room smalroom = new Room
                {
                    Id = room.Id,
                    Number = room.Number,
                    Cost = room.Cost,
                    Сapacity = room.Сapacity,
                    Type = room.Type,
                };
                _context.Room.Add(smalroom);
                _context.SaveChanges();

                RoomProp RoomBl = new RoomProp
                {
                    IdRoom = smalroom.Id,
                    Shower = room.Shower,
                    Restroom = room.Restroom,
                    Description = room.Description,
                    Bed = room.Bed,
                    Wifi = room.Wifi,
                    Tv = room.Tv,
                    Fridge = room.Fridge,
                };
                _context.RoomProp.Add(RoomBl);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteHandling(int id)
        {
            try
            {
                Handling handling =  _context.Handling.FirstOrDefault(p => p.Id == id);
                _context.Handling.Remove(handling);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteRomm(int id)
        {
            try
            {
                Room room = _context.Room.FirstOrDefault(p => p.Id == id);
                _context.Room.Remove(room);
                _context.SaveChanges();
                RoomProp roomProp = _context.RoomProp.FirstOrDefault(p => p.IdRoom == id);
                _context.RoomProp.Remove(roomProp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteClient(int id)
        {
            try
            {
                Client client = _context.Client.FirstOrDefault(p => p.Id == id);
                _context.Client.Remove(client);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool EditClient(Client clietn)
        {
            throw new NotImplementedException();
        }

        public bool EditHandling(Handling handling)
        {
            try
            {
                Handling handling1 = new Handling
                {
                    Id = handling.Id,
                    IdClient = handling.IdClient,
                    InCheck = handling.InCheck,
                    OutCheck = handling.OutCheck,
                    IdRoom = handling.IdRoom,
                    IdService = handling.IdService,
                    IdService2 = handling.IdService2,
                    IdService3 = handling.IdService3,
                    IdBooking = handling.IdBooking,
                    IdEmployee = handling.IdEmployee,
                };
                _context.Handling.Update(handling1);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public bool EditRoom(RoomBl room)
        {
            try
            {
                Room smalroom = new Room
                {
                    Id = room.Id,
                    Number = room.Number,
                    Cost = room.Cost,
                    Сapacity = room.Сapacity,
                    Type = room.Type,
                };
                _context.Room.Add(smalroom);
                _context.SaveChanges();

                RoomProp roomProp = new RoomProp
                {
                    IdRoom = smalroom.Id,
                    Shower = room.Shower,
                    Restroom = room.Restroom,
                    Description = room.Description,
                    Bed = room.Bed,
                    Wifi = room.Wifi,
                    Tv = room.Tv,
                    Fridge = room.Fridge,
                };
                _context.RoomProp.Update(roomProp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Client> GetClient()
        {
            try
            {
                //var client = 
                //var clinetWeb = _context.ClientWeb.ToList();
                //IEnumerable<Client> rez = (IEnumerable<ClientBl>)client.Join(clinetWeb,
                //    p => p.Id,
                //    t => t.IdClient,
                //    (p, t) => new {
                //        Id = p.Id,
                //        FirstName = p.FirstName,
                //        LastName = p.LastName,
                //        Surname = p.Surname,
                //        Passport = p.Passport,
                //        DatofBirth = p.DatofBirth,
                //        Adress = p.Adress,
                //        Telephone = p.Telephone,

                //        Email = t.Email,
                //        Password = t.Password,
                //        idRole = (int)t.IdRole,
                //    });
                return _context.Client.ToList(); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClientBl GetClient(int id)
        {
            Client client =  _context.Client.FirstOrDefault(p => p.Id == id);
            ClientWeb clientWeb = _context.ClientWeb.FirstOrDefault(p => p.IdClient == id);
            ClientBl clientBl = new ClientBl
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Surname = client.Surname,
                Passport = client.Passport,
                DatofBirth = client.DatofBirth,
                Adress = client.Adress,
                Telephone = client.Telephone,

                Email = clientWeb.Email,
                Password = clientWeb.Password,
                idRole = (int)clientWeb.IdRole,
            };
            return clientBl;
        }

        public IEnumerable<Handling> GetHandling()
        {
           return  _context.Handling.ToList();            
        }
    }
}
