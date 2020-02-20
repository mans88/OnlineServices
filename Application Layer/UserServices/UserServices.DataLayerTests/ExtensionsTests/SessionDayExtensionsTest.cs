using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.RegistrationServices.TransferObject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using OnlineServices.Common.RegistrationServices.Enumerations;
using RegistrationServices.DataLayer.Extensions;

namespace RegistrationServices.DataLayerTests
{
    [TestClass]
    public class SessionDayExtensionsTest
    {
        [TestMethod]
        public void Should_Parse_In_Same_DateTime_Format()
        {
            SessionDayTO sessionDay = new SessionDayTO()
            {
                Id = 1,
                Date = new DateTime(2020, 02, 03),
                PresenceType = SessionPresenceType.MorningOnly
            };

            Assert.AreEqual(sessionDay.Date, sessionDay.ToEF().ToTransfertObject().Date);
        }
    }
}