
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NigthWorks.Logic
{
    public interface IEventMainImageLogic
    {
        EventMainImage Read(int id);
        IEnumerable<EventMainImage> ReadAll();
        void Create(EventMainImage obj);
        void Update(EventMainImage obj);
        void Delete(int id);

        Post MostUsedWeapon();

        public IEnumerable<EventMainImage> GetAllPostByUserId(int id);
    }
}
