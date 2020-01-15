using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.IncidentRepositoryTests
{
    [TestClass]
    public class AddIncidentTest
    {
        [TestMethod]
        public void Add_ReturnIncidentTONotNull()
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
            var componentType = new ComponentTypeTO{Archived = false, Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl")};
            var addedComponentType = componentTypeRepository.Add(componentType);
            context.SaveChanges();
            //Issue
            var issue = new IssueTO{ Description = "prout", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = addedComponentType };
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
            //ACT
            var result = incidentRepository.Add(incident);
            context.SaveChanges();
            //ASSERT   
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Id);
        }
    }
}
