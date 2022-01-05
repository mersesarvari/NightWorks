using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Models;

namespace NigthWorks.Logic
{
    public interface IPost_Logic
    {
        Post Read(int id);
        IEnumerable<Post> ReadAll();
        void Create(Post obj);
        void Update(Post obj);
        void Delete(int id);

        Post MostUsedWeapon();

        public IEnumerable<Post> GetAllPostByUserId(int id);
    }
}
