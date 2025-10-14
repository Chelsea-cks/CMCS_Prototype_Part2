using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMCS_Prototype.Models;
using CMCS_Prototype.Services;
using System.Linq;

namespace CMCS_Prototype.Tests
{
    [TestClass]
    public class ClaimStoreTests
    {
        [TestInitialize]
        public void Init()
        {
            while (ClaimStore.Claims.Any()) ClaimStore.Claims.RemoveAt(0);
        }

        [TestMethod]
        public void AddClaim_IncreasesCount()
        {
            var c = new Claim { LecturerName = "A", HoursWorked = 2, HourlyRate = 100 };
            ClaimStore.AddClaim(c);
            Assert.AreEqual(1, ClaimStore.Claims.Count);
        }

        [TestMethod]
        public void ApproveByCoordinator_ChangesStatus()
        {
            var c = new Claim { LecturerName = "B", HoursWorked = 1, HourlyRate = 50 };
            ClaimStore.AddClaim(c);
            ClaimStore.ApproveByCoordinator(c.Id);
            Assert.AreEqual("Coordinator Approved", ClaimStore.GetById(c.Id)!.Status);
        }

        [TestMethod]
        public void RejectByManager_ChangesStatus()
        {
            var c = new Claim { LecturerName = "C", HoursWorked = 3, HourlyRate = 200 };
            ClaimStore.AddClaim(c);
            ClaimStore.ApproveByCoordinator(c.Id);
            ClaimStore.ApproveByManager(c.Id);
            Assert.AreEqual("Manager Approved", ClaimStore.GetById(c.Id)!.Status);
        }
    }
}
