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

namespace FacilityServices.DataLayerTests.RepositoriesTests.CommentRepositoryTests
{
    [TestClass]
    public class GetCommentsByIncidentIdTests
    {
        [TestMethod]
        public void GetCommentsByIncidentId_AddMultipleComments_ReturnRelevantComments()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FacilityContext(options);
            ICommentRepository commentRepository = new CommentRepository(context);
            IIncidentRepository incidentRepository = new IncidentRepository(context);
            IRoomRepository roomRepository = new RoomRepository(context);
            IFloorRepository floorRepository = new FloorRepository(context);
            IComponentTypeRepository componentTypeRepository = new ComponentTypeRepository(context);
            IIssueRepository issueRepository = new IssueRepository(context);

            var floor = new FloorTO { Number = 2 };
            var addedFloor = floorRepository.Add(floor);
            context.SaveChanges();

            RoomTO room = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = addedFloor };
            var addedRoom = roomRepository.Add(room);
            context.SaveChanges();

            var componentType = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1EN", "Name1FR", "Name1NL") };
            var addedComponentType = componentTypeRepository.Add(componentType);
            context.SaveChanges();

            var issue = new IssueTO { Description = "Broken thing", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = addedComponentType };
            var addedIssue = issueRepository.Add(issue);
            context.SaveChanges();

            var incident1 = new IncidentTO
            {
                Description = "This thing is broken!",
                Room = addedRoom,
                Issue = addedIssue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now,
                UserId = 1,
            };
            var incident2 = new IncidentTO
            {
                Description = "This thing is still broken after a week!",
                Room = addedRoom,
                Issue = addedIssue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now.AddDays(7),
                UserId = 1,
            };
            var addedIncident1 = incidentRepository.Add(incident1);
            var addedIncident2 = incidentRepository.Add(incident2);
            context.SaveChanges();

            var comment1 = new CommentTO
            {
                Incident = addedIncident1,
                Message = "I got in touch with the right people, it'll get fixed soon!",
                SubmitDate = DateTime.Now,
                UserId = 2
            };
            var comment2 = new CommentTO
            {
                Incident = addedIncident1,
                Message = "New ETA is Monday morning.",
                SubmitDate = DateTime.Now.AddDays(1),
                UserId = 2
            };
            var comment3 = new CommentTO
            {
                Incident = addedIncident2,
                Message = "It should be fixed very soon, sorry for the inconvenience!",
                SubmitDate = DateTime.Now.AddDays(8),
                UserId = 2
            };
            commentRepository.Add(comment1);
            commentRepository.Add(comment2);
            commentRepository.Add(comment3);
            context.SaveChanges();

            // Act
            var result1 = commentRepository.GetCommentsByIncident(addedIncident1.Id);
            var result2 = commentRepository.GetCommentsByIncident(addedIncident2.Id);

            // Assert
            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreEqual(2, result1.Count);
            Assert.AreEqual(1, result2.Count);
        }

        [TestMethod]
        public void GetCommentsByIncidentId_ThrowException_WhenUnexistingIncidentIdIsSupplied()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FacilityContext(options);
            ICommentRepository commentRepository = new CommentRepository(context);

            // Act & Assert
            Assert.ThrowsException<KeyNotFoundException>(() => commentRepository.GetCommentsByIncident(999));
        }
    }
}
