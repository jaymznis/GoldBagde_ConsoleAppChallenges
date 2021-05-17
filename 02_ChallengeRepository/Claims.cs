using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChallengeRepository
{
    public enum ClaimType { Car = 1, Home, Theft}
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public double Amount{ get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        {
            get
            {
                TimeSpan timeSpan = DateOfClaim - DateOfAccident;

                if(timeSpan.TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }      
            }
        }

        public Claims() { }

        public Claims ( int cID, ClaimType cT, string decription, double amount, DateTime dOA, DateTime dOC)
        {
            ClaimID = cID;
            Type = cT;
            Description = decription;
            Amount = amount;
            DateOfAccident = dOA;
            DateOfClaim = dOC;
        }
    }
}
