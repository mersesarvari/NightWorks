using NightWorks.Models;
using NigthWorks.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Client
{
    public static class EventManager
    {
        public static void EventTimer()
        { 
        
        
        }
        
        public static void EventLifetimeChecker(RestService r)
        {
            List<NWEvent> events = r.Get<NWEvent>("event");
            foreach (NWEvent e in events)
            {
                if (DateTime.Compare(e.Endingdate, DateTime.Now) <0)
                {
                    Console.WriteLine($"[{e.Id}] must be deleted because it is already expired");
                    r.Delete(e.Id, "event");
                    Console.WriteLine("Program deleted the event what was already expiring");
                }
            }
        }
    }
}
