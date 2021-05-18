using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ChallengeRepository
{
    public enum DoorAccess { A1 =1,A2,A3,A4,B1,B2,B3,B4}
    public class Badge
    {
        public int BadgeID
        {get;set;
           // get
            //{
             //   Random rnd = new Random();
            //    int badgeID = rnd.Next(12000, 19999);
          //      return badgeID;
           // }
        }
        public List<DoorAccess> DoorAccess { get; set; } = new List<DoorAccess>();

        public Badge() { }

        public Badge(int badgeID, List<DoorAccess> doorAccess ) 
        {
            BadgeID = badgeID;
            DoorAccess = doorAccess;
        }
    }
}
