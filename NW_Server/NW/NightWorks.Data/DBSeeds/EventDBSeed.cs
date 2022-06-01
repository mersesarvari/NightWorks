using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class EventDBSeed
    {
        public EventDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            List<NWEvent> events = new List<NWEvent>();
            NWEvent e1 = new NWEvent()
            {
                Id = 1,
                EventName = "Ultra Music Festival",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2021, 12, 15, 18, 00, 00),
                EventText = "The ULTRA brand in relation to live events was founded in 1997 in Miami by CEO, " +
                "Chairman & Executive Producer, Russell Faibisch, who began by producing electronic music events which " +
                "led to the inaugural Ultra Music Festival® in 1999 on the sands of Miami Beach The internationally  " +
                "renowned festival, which has taken place every March since its inception, celebrated its 21st anniversary on March 29 - 31, " +
                "2019 by bringing more than 170, 000 music enthusiasts to the sold -out waterfront event in Miami. " +
                "Ultra Music Festival®, which was voted the world’s #1 music festival by DJ Mag multiple times, " +
                "will make its triumphant return to its long-time home at Bayfront Park for its 22nd annual edition on March 20-22, 2019. " +
                "Choosing to follow a unique and creative vision, and a wholly organic growth focused on its true love for music, " +
                "artists and fans alike, the ULTRA and ULTRA Worldwide™ brands represent not only the world’s biggest and most successful remaining " +
                "INDEPENDENT electronic music festival brand, but also the most INTERNATIONAL music festival brand in the world.",
                Owner_Id = 1,
                Address_Id = 1,
                IconPhoto = "coins.jpg",
                CoverPhoto = @"event1.jpg"


            };
            NWEvent e2 = new NWEvent()
            {
                Id = 2,
                EventName = "Bath Party at Budapest",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2022, 01, 03, 00, 00, 00),
                EventText = "The story of Sparty starts in 1994, when a group of friends decided to bring together two things they love: the ancient " +
                "bath culture of Budapest, and modern electronic dance music. This is the place where magic happens every Saturday Adventurers " +
                "from all around the world gather at the one and only bath party, and spend the best night of their " +
                "life in the legendary Széchenyi Bath.So don’t say that we haven’t warned you: it’s going to be a party you will never forget.",
                Address_Id = 2,
                Owner_Id = 1,
                IconPhoto = "biodiversity.jpg",
                CoverPhoto = @"event2.jpg"
                

            };
            NWEvent e3 = new NWEvent()
            {
                Id = 3,
                EventName = "Lorem Ipsum event",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2022, 12, 15, 18, 00, 00),
                EventText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard " +
                "dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, " +
                "and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Address_Id = 3,
                Owner_Id = 2,
                IconPhoto = "plant.jpg",
                CoverPhoto = @"event3.jpg"

            };
            events.Add(e1);
            events.Add(e2);
            events.Add(e3);
            mb.Entity<NWEvent>().HasData(events);
        }
    }
}
