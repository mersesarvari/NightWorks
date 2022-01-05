using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Models;

namespace NigthWorks.Logic
{
    public interface IRole_Logic
    {

        Role Read(int id);
        IEnumerable<Role> ReadAll();
        void Create(Role obj);
        void Update(Role obj);
        void Delete(int id);
        Role MostUsedBrand();
    }
}
