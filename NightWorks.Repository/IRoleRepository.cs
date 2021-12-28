using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Data;
using NigthWorks.Models;

namespace NigthWorks.Repository
{
    public interface IRoleRepository
    {
        void Create(Role role);
        void Delete(int id);
        Role Read(int id);
        IQueryable<Role> ReadAll();
        void Update(Role role);
    }
}
