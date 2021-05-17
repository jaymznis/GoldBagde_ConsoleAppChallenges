using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChallengeRepository
{
    public class ClaimsRepo
    {
        private Queue<Claims> _claims = new Queue<Claims>();

        public bool AddClaim(Claims newClaim)
        {
            int claims = _claims.Count;

            _claims.Enqueue(newClaim);
            bool wasAdded = (_claims.Count > claims) ? true : false;
            return wasAdded;
        }

        public Queue<Claims> GetClaims()
        {
            return _claims;
        }

        public Claims GetClaimsByID(int claimID)
        {
            foreach (Claims claim in _claims)
            {
                if (claim.ClaimID == claimID && claim.GetType() == typeof(Claims))
                {
                    return (Claims)claim;
                }
            }
            return null;
        }

        public bool UpdateClaim(int claimID, Claims updateClaim)
        {
            Claims oldClaim = GetClaimsByID(claimID);
            {
                if (oldClaim != null)
                {
                    oldClaim.ClaimID = updateClaim.ClaimID;
                    oldClaim.Type = updateClaim.Type;
                    oldClaim.Description = updateClaim.Description;
                    oldClaim.Amount = updateClaim.Amount;
                    oldClaim.DateOfAccident = updateClaim.DateOfAccident;
                    oldClaim.DateOfClaim = updateClaim.DateOfClaim;

                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        //may not need
        public bool DeleteClaimByID(int claimID)
        {
            int count = _claims.Count;
            Claims claimToDelete = GetClaimsByID(claimID);
            if (claimToDelete == null)
            {
                return false;
            }
            else
            {

                Queue<Claims> newClaims = new Queue<Claims>(_claims.Where(x => x != claimToDelete));
                _claims = newClaims;
                if (count > _claims.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                } 
            }
        }
    }
}
