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

        public Dictionary<int, List<DoorAccess>> GetFullDictionary()
            {
            return _accessRepo;
            }
        public List<int> GetKeysInlDictionary()
        {
            List<int> listOfBadges = new List<int>();

            foreach (KeyValuePair<int, List<DoorAccess>> doors in _accessRepo)
            {
                listOfBadges.Add(doors.Key);
            }
            return listOfBadges;
        }

        public void AddDoorAccess(int badgeNum, DoorAccess door)
        {
            Badge badgeUpdate = GetByBadgeNum(badgeNum);
            badgeUpdate.DoorAccess.Add(door);
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
    }
}
