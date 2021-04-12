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
        public bool CreateClient(ClientBl client)
        {

            try
            {
                Client cl = new Client();


                cl.FirstName = client.FirstName;
                cl.LastName = client.LastName;
                cl.Surname = client.Surname;
                cl.Passport = client.Passport;
                cl.DatofBirth = (DateTime)client.DatofBirth;
                cl.Adress = client.Adress;
                cl.Telephone = client.Telephone;
                

                _context.Client.Add(cl);
                _context.SaveChanges();

                ClientWeb clientWeb = new ClientWeb
                {
                    IdClient = cl.Id,
                    Email = client.Email,
                    Password = client.Password,
                    IdRole = client.idRole,
                };

                _context.ClientWeb.Add(clientWeb);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            { 
                var x = ex.Message;
                return false;
                throw;
            }

        }

        public bool CreateHandling(HandlingBl handling)
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

        public bool DeleteRoom(int id)
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

        public bool EditClient(ClientBl client)
        {

            try
            {
                Client cl = new Client
                {
                    Id = client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Surname = client.Surname,
                    Passport = client.Passport,
                    DatofBirth = (DateTime)client.DatofBirth,
                    Adress = client.Adress,
                    Telephone = client.Telephone,
                };

                _context.Client.Update(cl);
                _context.SaveChanges();

                ClientWeb clientWeb = new ClientWeb
                {
                    IdClient = client.Id,
                    Email = client.Email,
                    Password = client.Password,
                    IdRole = client.idRole,
                };

                _context.ClientWeb.Update(clientWeb);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool EditHandling(HandlingBl handling)
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
                    //IdService = handling.IdService,
                    //IdService2 = handling.IdService2,
                    //IdService3 = handling.IdService3,
                    IdService = null,
                    IdService2 = null,
                    IdService3 = null,
                    IdBooking = null,
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
                _context.Room.Update(smalroom);
                _context.SaveChanges();

                RoomProp roomPropCheck = _context.RoomProp.FirstOrDefault(p => p.IdRoom == room.Id);
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
                if (roomPropCheck == null)
                {
                    _context.RoomProp.Add(roomProp);
                }
                else
                {
                    _context.RoomProp.Update(roomProp);
                }
                
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
                DatofBirth = client.DatofBirth == null? DateTime.Now : (DateTime)client.DatofBirth,
                Adress = client.Adress,
                Telephone = client.Telephone,

                Email = clientWeb.Email,
                Password = clientWeb.Password,
                idRole = clientWeb.IdRole == null? 0:(int)clientWeb.IdRole,
            };
            return clientBl;
        }

        public IEnumerable<HandlingBl> GetHandling()
        {
            var handling = _context.Handling.ToList();
            List<HandlingBl> handlingBl = new List<HandlingBl>();
             
            foreach (var item in handling)
            {                          
                handlingBl.Add(new HandlingBl
                {
                    Id = item.Id,
                    IdClient = item.IdClient,
                    LastName = _context.Client.FirstOrDefault(p => p.Id == item.IdClient).LastName,
                    InCheck = item.InCheck,
                    OutCheck = item.OutCheck,
                    IdRoom = item.IdRoom,
                    Room = (int)_context.Room.FirstOrDefault(p => p.Id == item.IdRoom).Number,
                    IdService = item.IdService == null ? 0 : item.IdService,
                    IdService2 = item.IdService2 == null ? 0 : item.IdService2,
                    IdService3 = item.IdService3 == null ? 0 : item.IdService3,
                    IdBooking = item.IdBooking == null ? 0 : item.IdBooking,
                    IdEmployee = item.IdEmployee
                });
            }
            
            return handlingBl;
        }

        public IEnumerable<HandlingBl> GetNowHandling(DateTime left, DateTime right)
        {
            return (from tab2 in GetHandling()
                    where ((tab2.InCheck > left) && (tab2.OutCheck < right)) || ((tab2.InCheck < left) && (tab2.OutCheck > left)) || ((tab2.InCheck < right) && (tab2.OutCheck > right))
                      
                       select tab2).ToList();
            //_context.Handling.Where(p => p.InCheck < left && p.OutCheck > right).ToList();
        }

        public RoomBl GetRoom(int id)
        {
            Room room = _context.Room.FirstOrDefault(p => p.Id == id);
            RoomProp roomProp = _context.RoomProp.FirstOrDefault(p => p.IdRoom == id);
            RoomBl roomBl;
            if (roomProp == null)
            {
                roomBl = new RoomBl
                {
                    Id = room.Id,
                    Number = room.Number,
                    Cost = (int)room.Cost,
                    Сapacity = room.Сapacity,
                    Type = room.Type,

                    Shower = false,
                    Restroom =  false,
                    Description = "",
                    Bed =  0,
                    Wifi = false,
                    Tv =  false,
                    Fridge =  false,
                };
            }
            else
            {
                roomBl = new RoomBl
                {
                    Id = room.Id,
                    Number = room.Number,
                    Cost = (int)room.Cost,
                    Сapacity = room.Сapacity,
                    Type = room.Type,

                    Shower = roomProp.Shower == null ? false : roomProp.Shower,
                    Restroom = roomProp.Restroom == null ? false : roomProp.Restroom,
                    Description = roomProp.Description == null ? "" : roomProp.Description,
                    Bed = roomProp.Bed == null ? 0 : roomProp.Bed,
                    Wifi = roomProp.Wifi == null ? false : roomProp.Wifi,
                    Tv = roomProp.Tv == null ? false : roomProp.Tv,
                    Fridge = roomProp.Fridge == null ? false : roomProp.Fridge,
                };
            }

            return roomBl;
        }

        public HandlingBl Handling(int id)
        {

            var handling = _context.Handling.FirstOrDefault(p => p.Id == id);
            return new HandlingBl
            {
                Id = handling.Id,
                IdClient = handling.IdClient,
                LastName = _context.Client.FirstOrDefault(p => p.Id == handling.IdClient).LastName,
                InCheck = handling.InCheck,
                OutCheck = handling.OutCheck,
                IdRoom = handling.IdRoom,
                Room = (int)_context.Room.FirstOrDefault(p => p.Id == handling.IdRoom).Number,
                IdService = handling.IdService == null ? 0 : handling.IdService,
                IdService2 = handling.IdService2 == null ? 0 : handling.IdService2,
                IdService3 = handling.IdService3 == null ? 0 : handling.IdService3,
                IdBooking = handling.IdBooking == null ? 0 : handling.IdBooking,
                IdEmployee = handling.IdEmployee
            };
        }
    }
}
