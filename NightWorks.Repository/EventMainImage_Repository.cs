﻿using NigthWorks.Data;
using NigthWorks.Models;
using NigthWorks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class EventMainImage_Repository : IEventMainImage_Repository
    {
        NWDbContext db;
        public void Create(EventMainImage item)
        {
            db.EventMainImages.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.EventMainImages.Remove(Read(id));
            db.SaveChanges();
        }

        public EventMainImage Read(int id)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.EventMainImages.FirstOrDefault(t => t.Id == id);
            }
        }

        public IQueryable<EventMainImage> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in that table");
            }
            else
            {
                return db.EventMainImages;
            }
            
        }

        public void Update(EventMainImage item)
        {
            var oldbrand = Read(item.Id);
            oldbrand.Data = item.Data;
            db.SaveChanges();
        }
    }
}