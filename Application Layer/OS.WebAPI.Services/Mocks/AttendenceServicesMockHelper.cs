using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineServices.Common.RegistrationServices;
using Moq;
using OnlineServices.Common.RegistrationServices.TransferObject;
using OnlineServices.Common.RegistrationServices.Enumerations;
using OnlineServices.AttendanceServices.Interfaces;
using OnlineServices.Common.AttendanceServices.TransfertObjects;

namespace OS.WebAPI.Services.Mocks
{
    public static class AttendenceServicesMockHelper
    {
        public static ICheckInRepository CheckInRepositoryObject()
        {
            var presenceRepositoryMOCK = new Mock<ICheckInRepository>();

            presenceRepositoryMOCK.Setup(homer => homer.Add(It.IsAny<CheckInTO>()))
                .Returns(new CheckInTO { Id = Guid.NewGuid() });

            return presenceRepositoryMOCK.Object;
        }


    }
}
