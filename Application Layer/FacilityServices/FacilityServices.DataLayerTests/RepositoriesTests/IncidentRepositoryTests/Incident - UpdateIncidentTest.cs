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
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.IncidentRepositoryTests
{
    [TestClass]
    public class UpdateIncidentTest
    {
        [TestMethod]
        public void Update_AddANewIncidentThenChangeStatusAndDescription_ReturnUpdatedIncident()
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
            var incident = new IncidentTO
            {
                Description = "No coffee",
                Room = addedRoom,
                Issue = addedIssue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now,
                UserId = 1,                
            };
            var addedIncident = incidentRepository.Add(incident);
            context.SaveChanges();
            //Change Incident's Status and Description
            addedIncident.Status = IncidentStatus.Resolved;
            addedIncident.Description = "No coffee, nor water !";
            //ACT
            var updatedIncident = incidentRepository.Update(addedIncident);
            //ASSERT
            Assert.IsNotNull(updatedIncident);
            Assert.AreEqual("No coffee, nor water !", updatedIncident.Description);
            Assert.AreEqual(IncidentStatus.Resolved, updatedIncident.Status);
        }

        [TestMethod]
        public void Update_ThrowException_WhenNullIsSupplied()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IIncidentRepository incidentRepository = new IncidentRepository(context);

            //ACT & ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => incidentRepository.Update(null));
        }

        [TestMethod]
        public void Update_ThrowException_WhenInvalidIdIsSupplied()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IIncidentRepository incidentRepository = new IncidentRepository(context);
            var incident1 = new IncidentTO { Id = 0 };
            var incident2 = new IncidentTO { Id = -1 };

            //ACT & ASSERT
            Assert.ThrowsException<ArgumentException>(() => incidentRepository.Update(incident1));
            Assert.ThrowsException<ArgumentException>(() => incidentRepository.Update(incident2));
        }

        [TestMethod]
        public void Update_ThrowException_WhenUnexistingIncidentIsSupplied()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IIncidentRepository incidentRepository = new IncidentRepository(context);
            var incident = new IncidentTO { Id = 999 };

            //ACT & ASSERT
            Assert.ThrowsException<KeyNotFoundException>(() => incidentRepository.Update(incident));
        }
    }
}