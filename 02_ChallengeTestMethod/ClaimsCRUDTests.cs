using _02_ChallengeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_ChallengeTestMethod
{
    [TestClass]
    public class ClaimsCRUDTests
    {
        [TestMethod]
        public void CreatClaimTestShouldWork()
        {
            Claims claim = new Claims();
            ClaimsRepo repo = new ClaimsRepo();

            bool add = repo.AddClaim(claim);

            Assert.IsTrue(add);
        }

        public void ReadClaims()
        {
            Claims claim = new Claims();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaim(claim);

            Queue<Claims> queue = repo.GetClaims();
            bool newQueue = queue.Contains(claim);
            Assert.IsTrue(newQueue);
        }

        private ClaimsRepo _repo;
        private Claims _claim;

        [TestInitialize]
        public void SeedTestMethod()
        {
            _repo = new ClaimsRepo();
            _claim = new Claims(1, ClaimType.Car, "Car accident on 465", 400, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));


            _repo.AddClaim(_claim);
        }
        [TestMethod]
        public void UpdateClaims()
        {
            Assert.AreEqual(_claim.ClaimID, 1);
            Assert.AreEqual(_claim.Amount, 400);

            _repo.UpdateClaim(1, new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12)));

            Assert.AreEqual(_claim.ClaimID, 2);
            Assert.AreEqual(_claim.Amount, 4000);

        }
        public void DeleteClaim()
        {
            bool deleted = _repo.DeleteClaimByID(2);

            Assert.IsTrue(deleted);

            _repo.AddClaim(_claim);

            bool deQueued = _repo.DequeueClaims();
            Assert.IsTrue(deQueued);
        }

    }
}
