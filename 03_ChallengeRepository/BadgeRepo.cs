using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ChallengeRepository
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, Badge> _accessRepo = new Dictionary<int, Badge>();
       // private readonly List<Badge> _badges = new List<Badge>();
        public bool AddBadge(Badge newBadge)
        {
            int oldRepo = _accessRepo.Count;

            _accessRepo.Add(newBadge.BadgeID,newBadge);
            bool wasAdded = (_accessRepo.Count > oldRepo) ? true : false;
            return wasAdded;

        }
        
        public void AddBadgeToDic(Badge badge)
        {
            _accessRepo.Add(badge.BadgeID, badge);
        } 
        public void RemoveBadgeFromDic(Badge badge)
        {
            _accessRepo.Remove(badge.BadgeID);
        }

        public Dictionary<int, Badge> GetFullDictionary()
            {
            return _accessRepo;
            }
        public List<int> GetKeysInlDictionary()
        {
            List<int> listOfBadges = new List<int>();

            foreach (KeyValuePair<int, Badge> badges in _accessRepo)
            {
                listOfBadges.Add(badges.Key);
            }
            return listOfBadges;
        }

        public void AddDoorAccess(int badgeNum, int door)
        {
            Badge badgeUpdate = GetByBadgeNum(badgeNum);
            badgeUpdate.DoorAccess.Add((DoorAccess)door); 
        }

        public void RemoveDoorAccess(int badgeNum, DoorAccess door)
        {
            Badge badgeUpdate = GetByBadgeNum(badgeNum);
            badgeUpdate.DoorAccess.Remove(door);
        }


        public Badge GetByBadgeNum(int badgeNum)
        {
            foreach (KeyValuePair<int, Badge> pair in _accessRepo)
            {
                if(pair.Key == badgeNum)
                {
                    //return new Badge(doors);
                    return pair.Value;
                }
            }
            return null;
        }

        public bool DictContainsKey(int badgeID)
        {
            if (_accessRepo.ContainsKey(badgeID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int StringisInt(string input)
        {
            int.TryParse(input, out int num);
            if (num != 0 )
            {
                return num;
            }
            else
            {
                return 0;
            }

        }
    }
}
