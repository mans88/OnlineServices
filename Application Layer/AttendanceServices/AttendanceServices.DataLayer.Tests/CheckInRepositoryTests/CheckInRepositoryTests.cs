using AttendanceServices.DataLayer;
using AttendanceServices.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.AttendanceServices.Interfaces;
using OnlineServices.Common.AttendanceServices.TransfertObjects;
using OnlineServices.Common.Extensions;
using System;

namespace AttendanceService.DataLayer.Tests
{
    [TestClass]
    public class CheckInRepositoryTests
    {
        [TestMethod]
        public void CheckInTable_NotNull_WhenCheckInTableIsCalledWithValidCredentials()
        {
            var checkIn = new CheckInRepository(new AzureStorageCredentials())
                .CheckInTable();

            Assert.IsNotNull(checkIn);
        }

        [TestMethod]
        public void CheckInTable_ReturnTableInstance_WhenAddIsCalledWithValidCheckIn()
        {
            var checkInArgs = new CheckInTO
            {
                SessionId = 999999999,
                AttendeeId = 333333333,
                CheckInTime = DateTime.Now
            };

            ICheckInRepository repo = new CheckInRepository(new AzureStorageCredentials()); 
            var addCheckIn = repo.Add(checkInArgs);

            Assert.IsNotNull(addCheckIn);
            Assert.AreNotEqual(Guid.Empty, addCheckIn.Id);
            Assert.AreEqual(checkInArgs.AttendeeId, addCheckIn.AttendeeId);
            Assert.IsTrue(addCheckIn.CheckInTime.IsSameDate(checkInArgs.CheckInTime));
            Assert.AreEqual(checkInArgs.SessionId, addCheckIn.SessionId);
        }

        [TestMethod]
        public void GetCheckInsInSession_ReturnCheckInList_WhenAValidSessionIdIsProvided()
        {
            var checkInArgs = new CheckInTO
            {
                SessionId = 999999999,
                AttendeeId = 333333333,
                CheckInTime = DateTime.Now
            };

            ICheckInRepository repo = new CheckInRepository(new AzureStorageCredentials());

            //Inserting at list one... for test sake
            var addCheckIn = repo.Add(checkInArgs);

            var checkInList = repo.GetCheckInsInSession(checkInArgs.SessionId);

            Assert.IsNotNull(checkInList);
            Assert.IsTrue(checkInList.Count>=1);
        }

        [TestMethod]
        public void GetAttendeeCheckIns_ReturnCheckInList_WhenAValidAttendeeIdIsProvided()
        {
            var checkInArgs = new CheckInTO
            {
                SessionId = 999999999,
                AttendeeId = 333333333,
                CheckInTime = DateTime.Now
            };

            ICheckInRepository repo = new CheckInRepository(new AzureStorageCredentials());

            //Inserting at list one... for test sake
            var addCheckIn = repo.Add(checkInArgs);

            var checkInList = repo.GetAttendeeCheckIns(checkInArgs.AttendeeId);

            Assert.IsNotNull(checkInList);
            Assert.IsTrue(checkInList.Count >= 1);
        }
    }
}
