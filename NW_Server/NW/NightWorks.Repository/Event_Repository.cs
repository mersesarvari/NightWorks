﻿using NigthWorks.Data;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class Event_Repository:IEvent_Repository 
    {
        NWDbContext db;
        public Event_Repository(NWDbContext db)
        {
            this.db = db;
        }        

        public void Create(NWEvent item)
        {
            var context = new NWDbContext();
            context.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = Read(id);
            if (x == null)
            {
                throw new InvalidOperationException(
                    "Event not found"
                );
            }
            db.Remove(x);
            db.SaveChanges();
        }

        public IList<NWEvent> GetEventsByUser(int id)
        {
            List<NWEvent> returndata= new List<NWEvent>();
            foreach (var item in db.Events)
            {
                if (item.Owner_Id == id)
                {
                    returndata.Add(item);
                }
            }
            return returndata;
        }

        public IList<Keyword> GetEventTypes(int id)
        {
            NWEvent x = Read(id);
            List<Keyword> types = new List<Keyword>();
            foreach (var item in x.Event_Keyword_Conns)
            {
                types.Add(item.Keyword);
            }
            return types;
        }

        public IList<User> GetEventUsers(int id)
        {
            /*
            NWEvent x = Read(id);
            List<User> u = new List<User>();
            foreach (var item in x.Owner_Id)
            {
                u.Add(item.User);
            }
            return u;
            */
            return null;
        }

        public NWEvent Read(int id)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                bool check = db.Events.Any(x => x.Id == id);
                if ( check== false)
                {
                    throw new Exception("There is no data with that id");
                }
                else
                {
                    //IList<NWEvent> events = new List<NWEvent>();
                    return db.Events.FirstOrDefault(t => t.Id == id);
                    //return events;
                }
                ;
            }
        }

        public IList<NWEvent> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Events.ToList();
            }
        }

        public IList<NWEvent> ReadAllByParameter(string parameter)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                if (parameter == null)
                {
                    return db.Events.ToList();
                }
                else
                {
                    var returndata = db.Events;
                    IList<NWEvent> list = new List<NWEvent>();
                    if (returndata.Where(x => x.Address.FormattedAddress.ToLower().Contains(parameter.ToLower())).ToList().Count() > 0)
                    {
                        list = returndata.Where(x => x.Address.FormattedAddress.ToLower().Contains(parameter.ToLower())).ToList();
                    }                   
                    else
                    {
                        throw new Exception("We dont find any elements");
                    }
                    return list;
                }

            }
        }        

        public void Update(NWEvent item)
        {
            var s = Read(item.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Event not found"
                );
            }

            s.Address_Id = item.Address_Id;
            s.EventName = item.EventName;
            s.Startingdate = item.Startingdate;
            s.CoverPhoto = item.CoverPhoto;
            s.IconPhoto = item.IconPhoto;
            s.Endingdate = item.Endingdate;
            s.EventText = item.EventText;
            
            db.SaveChanges();
        }

    }
}