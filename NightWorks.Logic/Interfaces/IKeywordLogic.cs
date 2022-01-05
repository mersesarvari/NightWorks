using NightWorks.Models;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public interface IKeywordLogic
    {
        Keyword Read(int id);
        IQueryable<Keyword> ReadAll();
        void Create(Keyword item);    
        void Update(Keyword item);
        void Delete(int id);
        List<NWEvent> GetTypeEvents(int id);
        
        
        
    }
}
