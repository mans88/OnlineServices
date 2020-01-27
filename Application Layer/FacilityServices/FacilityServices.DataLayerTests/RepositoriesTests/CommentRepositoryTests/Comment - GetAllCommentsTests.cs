using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Linq;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.CommentRepositoryTests
{
    [TestClass]
    public class GetAllCommentsTests
    {
        [TestMethod]
        public void GetAll_AddThreeComments_ReturnsCorrectNumberOfComments()
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

            var incident = new IncidentTO
            {
                Description = "This thing is broken !",
                Room = addedRoom,
                Issue = addedIssue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now,
                UserId = 1,
            };
            var addedIncident = incidentRepository.Add(incident);
            context.SaveChanges();

            var comment1 = new CommentTO
            {
                Incident = addedIncident,
                Message = "I got in touch with the right people, it'll get fixed soon!",
                SubmitDate = DateTime.Now,
                UserId = 2
            };
            var comment2 = new CommentTO
            {
                Incident = addedIncident,
                Message = "New ETA is Monday morning.",
                SubmitDate = DateTime.Now.AddDays(1),
                UserId = 2
            };
            var comment3 = new CommentTO
            {
                Incident = addedIncident,
                Message = "Postponed to Tuesday morning.",
                SubmitDate = DateTime.Now.AddDays(2),
                UserId = 2
            };
            commentRepository.Add(comment1);
            commentRepository.Add(comment2);
            commentRepository.Add(comment3);
            context.SaveChanges();

            // Act
            var result = commentRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }
    }
}
