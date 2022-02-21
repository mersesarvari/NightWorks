using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Data;
using NigthWorks.Models;

namespace NigthWorks.Repository
{
    public interface IRole_Repository
    {
        void Create(Role role);
        void Delete(string role);
        Role Read(string role);
        IList<Role> ReadAll();
        void Update(Role role);
    }
}
