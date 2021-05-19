using _03_ChallengeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_ChallengeTestMethod
{
    [TestClass]
    public class BadgeCRUDTests
    {
        [TestMethod]
        public void CreatBadgeTestShouldWork()
        {
            Badge badge = new Badge();
            BadgeRepo repo = new BadgeRepo();

            bool add = repo.AddBadge(badge);

            Assert.IsTrue(add);
        }

        public void ReadBadges()
        {
            BadgeRepo repo = new BadgeRepo();
            Badge badge = new Badge();
            repo.AddBadge(badge);

            Dictionary<int,Badge> dict = repo.GetFullDictionary();
            bool newDict = dict.ContainsValue(badge);
            Assert.IsTrue(newDict);
        }
        private BadgeRepo _repo;
        private Badge _badge;
        [TestInitialize]

        public void SeedTestMethod()
        {
            List<DoorAccess> listOne = new List<DoorAccess>
            {
                DoorAccess.A1,
                DoorAccess.B1,
                DoorAccess.B3
            };
            _repo = new BadgeRepo();
            _badge = new Badge(1234, listOne);

            _repo.AddBadge(_badge);
        }
        [TestMethod]
        public void UpdateBadges()
        {
            Assert.AreEqual(_badge.BadgeID, 1234);
            int count = _badge.DoorAccess.Count;
                Assert.AreEqual(count, 3);
            _repo.AddDoorAccess(1234,6);
            int newCount = _badge.DoorAccess.Count;
            Assert.AreEqual(newCount, 4);
        }
       
        public void DeleteBadge()
        {
            Dictionary<int, Badge> dict = _repo.GetFullDictionary();
            int count = dict.Count;
            Assert.AreEqual(count, 1);
            _repo.RemoveBadgeFromDic(_badge);
            Assert.AreEqual(count, 0);

        }

    }
}
