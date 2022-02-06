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
        IList<Post> ReadAll();
        void Create(Post obj);
        void Update(Post obj);
        void Delete(int id);

        Post MostUsedWeapon();

        public IList<Post> GetAllPostByUserId(int id);
    }
}
