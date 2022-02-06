using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Data;
using NigthWorks.Models;

namespace NigthWorks.Repository
{
    public interface IPost_Repository
    {
        void Create(Post post);
        void Delete(int id);
        Post Read(int id);
        IList<Post> ReadAll();
        void Update(Post post);

        
    }
}
