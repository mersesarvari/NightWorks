using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public interface IKeyword_Repository
    {
        Keyword Read(int id);
        IList<Keyword> ReadAll();
        void Create(Keyword item);    
        void Update(Keyword item);
        void Delete(int id);
        IList<NWEvent> GetTypeEvents(int id);
        Keyword ReadByParameter(string name);




    }
}
