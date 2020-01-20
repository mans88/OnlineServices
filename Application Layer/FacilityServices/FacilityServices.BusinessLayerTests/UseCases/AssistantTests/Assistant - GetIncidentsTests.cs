using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_GetIncidentsTests
    {

        public List<IncidentTO> GetTestsListOfIncidents()
        {
            //Floor
            var floor1 = new FloorTO { Number = 2 };
            var floor2 = new FloorTO { Number = -1 };
            //Room
            RoomTO room1 = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor1 };
            RoomTO room2 = new RoomTO { Name = new MultiLanguageString("Room2", "Room2", "Room2"), Floor = floor1 };
            RoomTO room3 = new RoomTO { Name = new MultiLanguageString("Room3", "Room3", "Room3"), Floor = floor2 };
            //Component
            var componentType1 = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl") };
            var componentType2 = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name2En", "Name2Fr", "Name2Nl") };
            //Issue
            var issue1 = new IssueTO { Description = "Plus de café", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = componentType1 };
            var issue2 = new IssueTO { Description = "Fuite d'eau", Name = new MultiLanguageString("Issue2EN", "Issue2FR", "Issue2NL"), ComponentType = componentType2 };
            var issue3 = new IssueTO { Description = "Plus de PQ", Name = new MultiLanguageString("Issue3EN", "Issue3FR", "Issue3NL"), ComponentType = componentType2 };
            //Incidents
            var incident1 = new IncidentTO { Room = room1, Issue = issue1, Status = IncidentStatus.Accepted };
            var incident2 = new IncidentTO { Room = room2, Issue = issue2, Status = IncidentStatus.Resolved };
            var incident3 = new IncidentTO { Room = room3, Issue = issue2, Status = IncidentStatus.Accepted };

            return new List<IncidentTO> { incident1, incident2, incident3 };
        }

        [TestMethod]
        public void GetIncidents_ReturnsIncidentInDB_WhenCalled()
        {
            var mockIncidentRepository = new Mock<IIncidentRepository>();
            mockIncidentRepository.Setup(x => x.GetAll()).Returns(GetTestsListOfIncidents());

            var mockUoW = new Mock<IFSUnitOfWork>();
            mockUoW.Setup(x => x.IncidentRepository).Returns(mockIncidentRepository.Object);

            var Assistante = new AssistantRole(mockUoW.Object);


            var incidents = Assistante.GetIncidents();

            Assert.AreEqual(GetTestsListOfIncidents().Count(), incidents.Count());
        }


        [TestMethod]
        public void GetIncidents_IncidentRepositoryIsCalledOnce_WhenCalled()
        {

            var mockIncidentRepository = new Mock<IIncidentRepository>();
            mockIncidentRepository.Setup(x => x.GetAll()).Returns(GetTestsListOfIncidents());

            var mockUoW = new Mock<IFSUnitOfWork>();
            mockUoW.Setup(x => x.IncidentRepository).Returns(mockIncidentRepository.Object);

            var Assistante = new AssistantRole(mockUoW.Object);

            Assistante.GetIncidents();

            mockIncidentRepository.Verify(x => x.GetAll(), Times.Once);
        }

    }
}
