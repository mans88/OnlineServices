using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FacilityServices.DataLayerTests.RepositoriesTests.IncidentRepositoryTests
{
    [TestClass]
    public class GetIncidentByUserId
    {
        [TestMethod]
        public void GetByUserId_AddMultipleIncidents_ReturnRelevantIncidents()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IIncidentRepository incidentRepository = new IncidentRepository(context);
            IRoomRepository roomRepository = new RoomRepository(context);
            IFloorRepository floorRepository = new FloorRepository(context);
            IComponentTypeRepository componentTypeRepository = new ComponentTypeRepository(context);
            IIssueRepository issueRepository = new IssueRepository(context);
            //Room(and it's floor)
            var floor = new FloorTO { Number = 2 };
            var addedFloor1 = floorRepository.Add(floor);
            context.SaveChanges();
            RoomTO room = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = addedFloor1 };
            var addedRoom = roomRepository.Add(room);
            context.SaveChanges();
            //Component
            var componentType = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl") };
            var addedComponentType = componentTypeRepository.Add(componentType);
            context.SaveChanges();
            //Issue
            var issue = new IssueTO { Description = "prout", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = addedComponentType };
            var addedIssue = issueRepository.Add(issue);
            context.SaveChanges();
            //Incident
            var incident1 = new IncidentTO
            {
                Description = "No coffee",
                Room = addedRoom,
                Issue = addedIssue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now,
                UserId = 1,
            };
            var incident2 = new IncidentTO
            {
                Description = "No coffee",
                Room = addedRoom,
                Issue = addedIssue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now,
                UserId = 1,
            };
            var incident3 = new IncidentTO
            {
                Description = "No coffee",
                Room = addedRoom,
                Issue = addedIssue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now,
                UserId = 2,
            };
            var addedIncident1 = incidentRepository.Add(incident1);
            var addedIncident2 = incidentRepository.Add(incident2);
            var addedIncident3 = incidentRepository.Add(incident3);
            context.SaveChanges();

            //ACT
            var result1 = incidentRepository.GetIncidentsByUserId(addedIncident1.UserId);
            var result2 = incidentRepository.GetIncidentsByUserId(addedIncident2.UserId);
            var result3 = incidentRepository.GetIncidentsByUserId(addedIncident3.UserId);

            //ASSERT
            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.IsNotNull(result3);
            Assert.AreEqual(2, result1.Count());
            Assert.AreEqual(2, result2.Count());
            Assert.AreEqual(1, result3.Count());
        }
    }
}
