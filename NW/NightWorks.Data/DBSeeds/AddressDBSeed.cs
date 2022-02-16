using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class AddressDBSeed
    {
        public AddressDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            List<Address> addresses = new List<Address>();
            Address a1 = new Address()
            {
                AddressId = 1,
                Longitude = 19.0891178,
                Latitude = 47.5818847,
                FormattedAddress = "Budapest, Ady Endre u. 3, 1044 Hungary"
            };
            Address a2 = new Address()
            {
                AddressId = 2,
                Longitude = 20.1436765,
                Latitude = 46.25701189999999,
                FormattedAddress= "Szeged, Mérey u. 13, 6722 Hungary"
            };
            Address a3 = new Address()
            {
                AddressId = 3,
                Longitude = 18.229786,
                Latitude = 46.072483,
                FormattedAddress = "Pécs, Bajcsy-Zsilinszky u. 5, 7622 Hungary"
            };
            addresses.Add(a1);
            addresses.Add(a2);
            addresses.Add(a3);
            mb.Entity<Address>().HasData(addresses);
        }
    }
}
